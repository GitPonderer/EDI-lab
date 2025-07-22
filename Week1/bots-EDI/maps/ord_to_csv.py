#!/usr/bin/env python3
"""
Bots-EDI mapping script: ORDERS → CSV
This script maps EDI ORDER messages to CSV format
"""

def main(inn, out):
    """
    Main mapping function for ORDERS to CSV conversion
    
    Args:
        inn: Input EDI message object
        out: Output CSV message object
    """
    
    # Extract order header information
    order_number = inn.get({'BOTSID': 'UNH', 'M_BGM': {'C_BGM01': None}})
    order_date = inn.get({'BOTSID': 'UNH', 'M_DTM': {'C_DTM01': None}})
    
    # Extract buyer information
    buyer_name = inn.get({'BOTSID': 'UNH', 'M_NAD': {'3035': 'BY', 'C_NAD03': None}})
    
    # Process line items
    for line_item in inn.getloop({'BOTSID': 'UNH'}, {'BOTSID': 'M_LIN'}):
        # Extract product information
        product_code = line_item.get({'BOTSID': 'M_LIN', 'C_LIN02': None})
        quantity = line_item.get({'BOTSID': 'M_LIN', 'M_QTY': {'C_QTY01': None}})
        price = line_item.get({'BOTSID': 'M_LIN', 'M_PRI': {'C_PRI01': None}})
        
        # Map to CSV output
        csv_line = out.putloop({'BOTSID': 'csv_record'})
        csv_line.put({'BOTSID': 'csv_record', 'order_number': order_number})
        csv_line.put({'BOTSID': 'csv_record', 'order_date': order_date})
        csv_line.put({'BOTSID': 'csv_record', 'buyer_name': buyer_name})
        csv_line.put({'BOTSID': 'csv_record', 'product_code': product_code})
        csv_line.put({'BOTSID': 'csv_record', 'quantity': quantity})
        csv_line.put({'BOTSID': 'csv_record', 'price': price})

if __name__ == '__main__':
    print("Bots-EDI mapping script: ORDERS → CSV")
    print("This script would be used by Bots-EDI engine to transform EDI ORDERS messages to CSV format")