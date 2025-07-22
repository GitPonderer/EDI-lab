# Invoice Message Example - Complete Information

## Invoice Overview

This is an example of an Invoice message sent from the supplier identified by GLN 4012345500004 with a VAT registration number VR12345 to a buyer identified by GLN 5412345000013 with a VAT registration number 4146023.

The Commercial Invoice with reference IN432097 is sent the 8 March 2002. It is invoicing goods ordered the 12 February 2002 according to the purchase order with reference ORD9523 and the price list PL99523 of 1 January 2002. The ordered goods were shipped by the supplier on 15 February 2002 to the delivery point identified by the location number 5412345678908. The reference number for the delivery was 53662.

## Payment Terms

The invoicing currency is Euros. The basic payment terms are two months net with a 2.5% discount if payment is received within 10 days of the invoice date. Payment is to be made directly to the supplier's bank account.

Additionally, for the whole invoice there is a freight charge of 120 EUR plus a standard 19% VAT rate.

## Line Items

The invoice consists of two line items:

### Line Item 1
- **Product**: Identified by GTIN 4000862141404
- **Quantity**: 40 units at a gross unit price (catalogue price) of 60 EUR
- **Discount**: 10% discount on the gross unit price
- **VAT Rate**: 21%
- **Net Line Amount**: 2160 EUR
- Note: Allowances or charges must be specified for calculation

### Line Item 2
- **Product**: Identified by GTIN 5412345111115
- **Delivered Units**: 5 units
- **Price**: Net unit price per kilogram of 200 EUR
- **Invoiced Quantity**: Total weight of the 5 units = 12.65 KGs
- **Net Line Amount**: 2530 EUR
- **VAT Rate**: 19%
- Note: Allowances or charges may be specified here for information not calculation purposes

## Financial Calculations

| Description | Amount (EUR) | Qualifier |
|-------------|--------------|-----------|
| Net line amounts | 2160 + 2530 = 4690 | 79 MOA (VAT Exclusive) |
| Additional amounts | 120 | 131 MOA after ALC |
| Amount Subject to tax | 4810 | 125 MOA |
| **VAT Calculations** | | |
| VAT 19% (2530 × 0.19) | 480.70 | 124 MOA after TAX |
| VAT 19% (120 × 0.19) | 22.80 | 124 MOA after TAX |
| VAT 19% Subtotal | 503.50 | |
| VAT 21% (2160 × 0.21) | 453.60 | 124 MOA after TAX |
| **Total tax amount** | **957.10** | **176 MOA** |
| **Message monetary amount** | **4810 + 957.10 = 5767.10** | **86 MOA** |
| Amount subject to payment discount | 5767.10 | 129 MOA |

## EDI Message Structure

```
UNH+ME000001+INVOIC:D:01B:UN:EAN011'    Message header
BGM+380+IN432097'                        Commercial invoice number IN432097
DTM+137:20020308:102'                    Message date 8th March 2002
PAI+::42'                               Instructions to pay in bank account
RFF+ON:ORD9523'                         Purchase order invoiced number ORD9523
DTM+171:20020212:102'                   Reference date 12th February 2002
RFF+PL:PL99523'                         Price list reference number PL99523
DTM+171:20020101:102'                   Reference date 1st January 2002
RFF+DQ:53662'                           Reference delivery note number 53662
DTM+171:20020215:102'                   Reference date 15th February 2002
NAD+BY+5412345000013::9'                Buyer identified by GLN 5412345000013
RFF+VA:4146023'                         VAT reference number of the buyer 4146023
NAD+SU+4012345500004::9'                Supplier identified by GLN 4012345500004
RFF+VA:VR12345'                         VAT reference number of the supplier VR12345
NAD+DP+5412345678908::9'                Delivery party identified by GLN 5412345678908
CUX+2:EUR:4'                            Reference currency is Euros
PAT+1++5:3:M:2'                         Payment terms 2 months after date of invoice
PAT+22++5:3:D:10'                       Payment discount for payment 10 days after date of invoice
PCD+12:2.5:13'                          Percentage information for the allowances or charges 2.5%
ALC+C++6++FC'                           Charges to be paid by customer
MOA+23:120'                             Monetary amount for the charge 120 EUR to be added
TAX+7+VAT+++:::19+S'                    Type of tax is value added tax at 19%
MOA+124:22.80'                          Tax monetary amount 22.80 EUR
LIN+1++4000862141404:SRV'               Line item 1 identified by GTIN 4000862141404
QTY+47:40'                              Invoiced quantity 40
MOA+203:2160'                           Line item amount 2.160 EUR
PRI+AAB:60:CA'                          Gross calculation price of 60 which does not include any allowance or charges, from the catalogue
TAX+7+VAT+++:::21+S'                    Type of tax for the line item is value added tax 21%
MOA+124:453.60'                         Tax monetary amount 453.60 EUR
ALC+A'                                  Allowances
PCD+1:10'                               Percentage information for the allowances 10%
LIN+2++5412345111115:SRV'               Line item 2 identified by GTIN 5412345111115
QTY+46:5'                               Delivered quantity 5
QTY+47:12.65:KGM'                       Invoiced quantity 12.65 Kg
MOA+203:2530'                           Line item amount 2.530 EUR
PRI+AAA:200:CA::1:KGM'                  Net price of 200 per Kg from the catalogue, this price includes allowances and charges
TAX+7+VAT+++:::19+S'                    Type of tax for the line item is value added tax 19%
MOA+124:480.70'                         Tax monetary amount 480.70 EUR
UNS+S'                                  To separate the detail section from the summary section
CNT+2:2'                                Total number of line items 2
MOA+86:5767.10'                         Message total monetary amount 5.767,10 EUR
MOA+79:4690'                            Message total line items amount 4.690 EUR
MOA+129:5767.10'                        Total amount subject to payment discount 5.767.10 EUR
MOA+125:4810'                           Message total taxable amount 4.810 EUR
MOA+176:957.10'                         Message total tax amount 957,10 EUR
MOA+131:120'                            Total charges/allowances 120 EUR
TAX+7+VAT+++:::19+S'                    Type of tax for the total message is value added tax 19%
MOA+124:503.50'                         Tax monetary amount 503.50 EUR
TAX+7+VAT+++:::21+S'                    Type of tax for the total message is value added tax 21%
MOA+124:453.60'                         Tax monetary amount 453.60 EUR
ALC+C++++FC'                            Freight charge
MOA+131:120'                            Total charges 120 EUR
UNT+53+ME000001'                        Total number of segments in the message equals 53
```