using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace OOP14
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //a.бинарный формат
            Book book = new Book("Stephen", "King", "The Green Mile");
            Console.WriteLine("Binary:");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Bin.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book);
            }
            using (FileStream fs = new FileStream("Bin.dat", FileMode.OpenOrCreate))
            {
                Book newBook = (Book)formatter.Deserialize(fs);
                newBook.Info();
            }

            //b.SOAP формат
            Console.WriteLine("\nSOAP:");
            SoapFormatter soapformatter = new SoapFormatter();  // почти xml

            using (Stream fs = new FileStream("SOAP.dat", FileMode.OpenOrCreate))
            {
                soapformatter.Serialize(fs, book);
            }
            using (Stream fs = new FileStream("SOAP.dat", FileMode.OpenOrCreate))
            {
                Book newBook1 = (Book)soapformatter.Deserialize(fs);
                newBook1.Info();
            }

            //c.JSON формат
            Console.WriteLine("\nJSON:");
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Book));
            using (FileStream fs = new FileStream("JSONForm.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, book);
            }
            using (FileStream fs = new FileStream("JSONForm.json", FileMode.OpenOrCreate))
            {
                Book newB = jsonFormatter.ReadObject(fs) as Book;
                newB.Info();
            }

            //d.XML формат
            Console.WriteLine("\nXML:");
            XmlSerializer xml = new XmlSerializer(typeof(Book));
            using (FileStream fs = new FileStream("XMLSerial.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, book);
            }
            using (FileStream fs = new FileStream("XMLSerial.xml", FileMode.OpenOrCreate))
            {
                Book newBook3 = xml.Deserialize(fs) as Book;
                newBook3.Info();
            }

            //2.Создайте коллекцию(массив) объектов и выполните сериализацию / десериализацию.
            Book b1 = new Book("Stephen", "Hawking", "A Brief History of Time");
            Book b2 = new Book("Stephen", "Hawking", "The Grand Design");
            Book b3 = new Book("Stephen", "Hawking", "My Brief History");
            Book[] bs = new Book[] { b1, b2, b3 };
            Console.WriteLine("\nArray:");
            DataContractSerializer array = new DataContractSerializer(typeof(Book[]));
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                array.WriteObject(fs, bs);
            }
            using (FileStream fs = new FileStream("array.xml", FileMode.OpenOrCreate))
            {
                Book[] newB = (Book[])array.ReadObject(fs);
                foreach (Book b in newB)
                {
                    b.Info();
                }
            }

            //3.Используя XPath напишите два селектора для вашего XML документа.
            Console.WriteLine("\nXPath:");  //язык запросов к элементам XML-документа
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("books.xml");
            XmlElement xRoot = xDoc.DocumentElement;    
            Console.WriteLine("All nodes:");
            XmlNodeList all = xRoot.SelectNodes("*");   //выбирает все узлы
            foreach (XmlNode x in all)
            {
                Console.WriteLine(x.OuterXml);         
            }
            Console.WriteLine("Several parts of the book:");
            XmlNodeList parts = xRoot.SelectNodes("Book");  //выбирает узлы Book
            foreach (XmlNode x in parts)
            {
                Console.WriteLine(x.SelectSingleNode("NameOfW").InnerText);
            }

            //4.Используя Linq to XML(или Linq to JSON) создайте новый xml(json) - документ и напишите несколько запросов.
            Console.WriteLine("\nLINQ to XML:");
            XDocument xdoc = new XDocument();
            XElement bookstore = new XElement("bookstore"); //первый эл
            XAttribute bs_name_attr = new XAttribute("name", "OZ");
            XElement bs_country_elem = new XElement("country", "BY");
            XElement bs_city_elem = new XElement("city", "Minsk");
            bookstore.Add(bs_name_attr);            //заполняем аттрибутом и элем-ми
            bookstore.Add(bs_country_elem);
            bookstore.Add(bs_city_elem);

            XElement bookstore2 = new XElement("bookstore");    
            XAttribute bs2_name_attr = new XAttribute("name", "XLMedia");
            XElement bs2_country_elem = new XElement("country", "RU");
            XElement bs2_city_elem = new XElement("city", "Moscow");
            bookstore2.Add(bs2_name_attr);          
            bookstore2.Add(bs2_country_elem);
            bookstore2.Add(bs2_city_elem);

            XElement root = new XElement("root");   //корневой элемент
            root.Add(bookstore);
            root.Add(bookstore2);
            xdoc.Add(root);
            xdoc.Save("linq.xml");                  //сохраняем в файл

            Console.WriteLine("Request 1: What is a bookstore in BY?"); //1-й запрос
            IEnumerable<XElement> items = xdoc.Element("root").Elements("bookstore")
                .Where(p => p.Element("country").Value == "BY");
            foreach (XElement item in items)
            {
                Console.WriteLine(item.Attribute("name").Value + " - " + item.Element("country").Value + " - " + item.Element("city").Value);
            }
            Console.WriteLine("Request 2: In which country is there a bookstore called 'XLMedia'?");//2-й запрос
            IEnumerable<XElement> coun = xdoc.Element("root").Elements("bookstore")
                .Where(p => p.Attribute("name").Value == "XLMedia");
            foreach (XElement c in coun)
            {
                Console.WriteLine(c.Attribute("name").Value + " - " + c.Element("country").Value + " - " + c.Element("city").Value);
            }
            Console.ReadKey();
        }
    }
}
