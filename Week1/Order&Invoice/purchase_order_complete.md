# Purchase Order Message Example - Complete Information

## Purchase Order Overview

This is an example of a simple purchase order for one line item between a buyer identified by GLN 5412345000013 and a supplier identified by GLN 4012345500004.

The order is placed the 30th August 2002. It is based on a contract drawn 25th August 2002 with reference 652744. The purchase order buyer's reference is 128576.

## Product Details

The buyer orders 48 units of the product identified by GTIN 400862141404 at a net unit price of 14.58 pounds sterling for a total item amount of 699.84 pounds sterling. The net unit price for the product is covered by a contract specific to that product dated the 1st August 2002 with a reference number of AUG93RNG04.

## Currency and Pricing

A currency exchange rate of 1.67 Euros to a one pound sterling valid for the month of August 2002 is specified. The product is a standard rated VAT item with a VAT rate of 17.5%. The buyer's internal product code for the product is identified as ABC1234.

## Special Requirements

The buyer requests that the seller mark the expiry date for the products on the product packaging.

## Delivery Information

The delivery of the product is requested for two locations. Both locations are to get 24 pieces:
- **Location 3312345502000**: Requested delivery for the 15th of September 2002 (24 pieces)
- **Location 3312345501003**: Requested delivery for the 13th of September 2002 (24 pieces)

## Order Summary

| Field | Value |
|-------|-------|
| Order Date | 30th August 2002 |
| Order Number | 128576 |
| Contract Reference | 652744 |
| Contract Date | 25th August 2002 |
| Product GTIN | 4000862141404 |
| Buyer's Product Code | ABC1234 |
| Quantity | 48 units |
| Unit Price | 14.58 GBP |
| Total Amount | 699.84 GBP |
| Currency | Pounds Sterling (ordering), Euros (invoicing) |
| Exchange Rate | 1 GBP = 1.67 EUR |
| VAT Rate | 17.5% |
| Price List Reference | AUG93RNG04 |
| Price List Date | 1st August 2002 |

## Party Information

| Party | GLN | VAT Number |
|-------|-----|------------|
| Buyer | 5412345000013 | 87765432 |
| Supplier | 4012345500004 | 56225432 |

## Contact Information

- **Order Contact**: P FORGET
- **Telephone**: 0044715632478

## Delivery Terms

- **Terms**: CIF (Cost, Insurance and Freight)
- **Transport**: Truck
- **Named Port**: Brussels
- **Packaging**: Two packages (cases) barcoded with ITF14

## EDI Message Structure

```
UNH+ME000001+ORDERS:D:01B:UN:EAN010'    Message header
BGM+220+128576+9'                        Order number 128576
DTM+137:20020830:102'                    Message date 30th of August 2002
PAI+::42'                               Instruction to pay in Bank Account
ALI+++136'                              Group conditions apply to the entire ORDER
FTX+ZZZ+1+001::91'                      Free text mutually defined
RFF+CT:652744'                          Order is based on contract number 652744
DTM+171:20020825:102'                   Date of contract 25th of August 2002
NAD+BY+5412345000013::9'                Buyer is identified by GLN 5412345000013
RFF+VA:87765432'                        Buyer's VAT number is 87765432
CTA+OC+:P FORGET'                       Order contact is P Forget
COM+0044715632478:TE'                   Telephone number of order contact
NAD+SU+4012345500004::9'                Supplier is identified by GLN 4012345500004
RFF+VA:56225432'                        Supplier's VAT number is 56225432
CUX+2:GBP:9+3:EUR:4+1.67'              Ordering currency is Pounds Sterling with the invoicing currency identified as Euros. The exchange rate between them is 1 Pound Sterling equals 1.67 Euros
DTM+134:2002080120020831:718'           Period on which rate of exchange date is based is the 1st of August 2002 - 31st of August 2002
TDT+20++30+31'                          Order requests that the main carriage transport used to deliver the goods is a truck
TOD+3++CIF:2E:9'                        Terms of delivery are to be Cost, Insurance and Freight
LOC+1+BE-BRU'                           The named port is Brussels
LIN+1++4000862141404:SRV'               First product order is identified by the GTIN 4000862141404
PIA+1+ABC1234:IN'                       In addition the buyer's part number ABC1234 is provided
IMD+C++TU::9'                           The ordered item is a traded unit
QTY+21:48'                              Ordered quantity is 48 units
MOA+203:699.84'                         Value of order line is 699.84 Pounds Sterling
PRI+AAA:14.58:CT:AAE:1:KGM'             Fixed net calculation price is 14.58 Pounds Sterling
RFF+PL:AUG93RNG04'                      Price is taken from the price list AUG93RNG04
DTM+171:20020801:102'                   Price list date 1st of August 2002
PAC+2+:51+CS'                           Two packages (cases) barcoded with ITF14
PCI+14'                                 The expiry date of the product is to be marked on its packaging
LOC+7+3312345502000::9'                 The second place to which the product is to be delivered is identified by GLN 3312345502000
QTY+11:24'                              The quantity to be delivered at this location is 24
DTM+2:20020915:102'                     The quantity should be delivered on the 15th of September 2002
LOC+7+3312345501003::9'                 The first place to which the product is to be delivered is identified by GLN 3312345501003
QTY+11:24'                              The quantity to be delivered at this location is 24
DTM+2:20020913:102'                     The quantity should be delivered on the 13th of September 2002
TAX+7+VAT+++:::17.5+S'                  The product is subject to the standard VAT rate of 17.5%
UNS+S'                                  Message detail/summary separator
CNT+2:1'                                Count of the number of LIN segments in the message
UNT+39+ME000001'                        Total number of segments in the message equals 39
```