using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breadcrumb
{
    class BreadcrumbProgram
    {
        static void Main(string[] args)
        {
            setupMenuNodeMap();

			// Using a default parameter, we can hide the extra parameter from the interface. It does not seem Java has this feature.
            String breadcrumb = createBreadcrumb("Star Wars");
            Console.WriteLine(breadcrumb == String.Empty ? "No path found" : breadcrumb);
            Console.ReadLine();
        }

        static String[] getMenuChildNodes(String nodeName)
        {
            if (menu.ContainsKey(nodeName))
            {
                return menu[nodeName];
            }
            else return new String[0];
        }

        // targetNodeName: The original, single parameter in the specification
        //
        // startNodeName:  The additional parameter required to make this work with recursion. Using a default value for our startNodeName, 
        //                 the second parameter can be optional in the interface, but available for recursion.
        //
        static String createBreadcrumb(String targetNodeName, String startNodeName = "Books")
        {
            // If we found a match, then we can simply return. We've reached the endpoint of the breadcrumb trail.
            if (targetNodeName == startNodeName)
            {
                return targetNodeName;
            }
            else
            {
                String[] childNodes = getMenuChildNodes(startNodeName);
                foreach (String node in childNodes)
                {
                    String breadcrumb = createBreadcrumb(targetNodeName, node);
                    // When breadcrumb is an empty string, this path was a dead end. Otherwise, we can start unwinding the stack to build the breadcrumb.
                    if (breadcrumb != String.Empty)
                    {
                        return startNodeName + " > " + breadcrumb;
                    }
                }
            }

            // If this node is not a match and we found no match in the children, then no match was found. Return empty string.
            return String.Empty;
        }


        private static Dictionary<String, String[]> menu;
        private static void setupMenuNodeMap()
        {
            menu = new Dictionary<String, String[]>();

            String[] booksNode = { "Classics", "Non-Fiction", "Sci-Fi" };
            menu.Add("Books", booksNode);

            String[] classicsNode = { "Treasure Island", "The Great Gatsby", "Moby Dick" };
            menu.Add("Classics", classicsNode);

            String[] nonFictionNode = { "Birthday Letters", "The Selfish Gene", "Life on the Mississippi" };
            menu.Add("Non-Fiction", nonFictionNode);

            String[] sciFiNode = { "Star Wars", "Star Trek", "Ender's Game" };
            menu.Add("Sci-Fi", sciFiNode);
        }
    }
}
