using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppServiceAtomicInfo.atomicInfo;
using System.Xml;

namespace AppServiceAtomicInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            atomicInfo.periodictable tableInfo = new atomicInfo.periodictable();

            string elements = tableInfo.GetAtoms();

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(elements);

            doc.Save("atoms.xml");

            XmlNodeList elementList = doc.DocumentElement.SelectNodes("Table/ElementName");
            string[] elementArray = new string[elementList.Count];

            for (int i = 0; i < elementList.Count; i++)
            {
                elementArray[i] = elementList[i].InnerText;
            }

            string input = "";

            bool loop = true;
            while (loop)
            {
                Console.Write("Enter Element Name, ? for a list of elements, or enter to exit: ");
                input = Console.ReadLine();

                if (input == "?")
                {
                    ListElements(elementList);
                }
                else if (input == "")
                {
                    loop = false;
                }
                else
                {
                    if (elementArray.Contains(input))
                    {
                        try
                        {
                            string atomicXmlInfo = tableInfo.GetAtomicNumber(input);

                            doc.LoadXml(atomicXmlInfo);
                            doc.Save("atomicNumber.xml");

                            foreach (XmlNode node in doc.DocumentElement.SelectSingleNode("Table").ChildNodes)
                            {
                                Console.WriteLine("{0}: {1}", node.Name, node.InnerText);
                            }
                            Console.WriteLine("\n");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nWeb Service did not respond\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid element name\n");
                    }
                }
            }
        }

        private static void ListElements(XmlNodeList elementList)
        {
            int i = 0;

            
            foreach (XmlNode element in elementList)
            {
                if (i % 4 == 0)
                {
                    Console.Write("\n");
                }
                Console.Write(element.InnerText + ",");
                for (int j = element.InnerText.Length; j < 20; j++)
                {
                    Console.Write(" ");
                }
                i++;
            }
            Console.WriteLine("\n");
        }
    }
}
