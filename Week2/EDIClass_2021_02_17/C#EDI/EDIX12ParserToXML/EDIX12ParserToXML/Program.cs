using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Xml; 

namespace EDIX12Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string ediFilename = @"c:\EDIClass\Samples\Sample_850_01_Orig.edi";
            string ediFileContents = File.ReadAllText(ediFilename);

            //temporary variables for parsing 
            string poNumber = ""; 

            Console.WriteLine(ediFileContents);

            string elementSeparator = ediFileContents.Substring(108, 1);
            string lineSeparator = ediFileContents.Substring(110, 1);

            ediFileContents = ediFileContents.Replace("\r", "").Replace("\n", "");

            Console.WriteLine("elementSeparator=" + elementSeparator);
            Console.WriteLine("lineSeparator=" + lineSeparator);

            StringBuilder sbXML = new StringBuilder();
            sbXML.Append("<EDI850>"); 

            string[] lines = ediFileContents.Split(char.Parse(lineSeparator));
            Console.WriteLine("Number of lines=" + lines.Length);

            bool segmentNeedsClose = false;
            string segment = "";

            foreach (string line in lines)
            {
                Console.WriteLine(line); 
                string[] elements = line.Split(char.Parse(elementSeparator));
                int loopCounter = 0;
                string elNum = "";
                string elName = ""; 
                foreach (string el in elements)
                {
                    if (loopCounter == 0)
                    {
                        if (segmentNeedsClose)
                        {
                            if (!String.IsNullOrEmpty(segment))
                            { 
                                sbXML.Append("</" + segment + ">");
                            }
                        }

                        segment = el;
                        if (!String.IsNullOrEmpty(segment))
                        {
                            sbXML.Append("<" + segment + ">");
                        }
                        segmentNeedsClose = true;

                    }
                    else
                    {
                        elNum = loopCounter.ToString("D2");
                        elName = segment + elNum; 
                        Console.WriteLine(elName + "=" + el);
                        sbXML.Append("<" + elName + ">" + el + "</" + elName + ">");

                        if (elName == "BEG03")
                        {
                            poNumber = el; 
                        }
                    }
                    loopCounter++;
                }
                /*
                Console.WriteLine("*** PONum=" + po850.PONum + " PODate=" + po850.PODate + " POType=" + po850.POType);
                Console.WriteLine("*** Vendor=" + po850.VendorNumber + " BuyerName=" + po850.BuyerName + " Telephone=" + po850.BuyerTelephone);
                foreach (PurchaseOrder850LineItem item in po850.LineItems)
                {
                    Console.WriteLine("***** " +
                                      item.lineItem + " " +
                                      " qty=" + item.quantity + " " +
                                      " uom=" + item.uom + " " +
                                      " price=" + item.price + " " +
                                      " basis=" + item.basisOfUnitPrice + " " +
                                      " desc=" + item.description +
                                      " reqDate=" + item.dateRequired
                                      );
                }
                Console.ReadLine(); 
                */ 
            }

            sbXML.Append("</EDI850>");
            // TODO Write XML to File 
            XmlDocument xmlDoc = new XmlDocument();
            string strXML = sbXML.ToString(); 
            xmlDoc.LoadXml(strXML);

            string outputFilename = @"c:\EDIClass\EDIToXML\" + 
                Path.GetFileName(ediFilename);
            // add ponumber from BEG03 to filename 
            outputFilename = outputFilename.Replace(".edi",
                "_" + poNumber + ".xml");

            xmlDoc.Save(outputFilename); 


            Console.WriteLine("\n\n Press enter to end:");
            Console.ReadLine(); 
        }
    }
}
