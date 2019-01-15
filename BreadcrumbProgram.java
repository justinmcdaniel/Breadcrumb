
import java.util.HashMap; 

public class BreadcrumbProgram
{
  public static void main(String[] args)
  {
    setupMenuNodeMap();
    
    String breadcrumb = createBreadcrumb("Books", "Books");
    System.out.println(breadcrumb == "" ? "No path found" : breadcrumb);
  }
  
  
  // targetNodeName: The original, single parameter in the specification
  //
  // startNodeName:  The additional parameter required to make this work with recursion. 
  //
  static String createBreadcrumb(String targetNodeName, String startNodeName)
  {
    // If we found a match, then we can simply return. We've reached the endpoint of the breadcrumb trail.
    if (targetNodeName == startNodeName)
    {
      return targetNodeName;
    }
    else
    {
      String[] childNodes = getMenuChildNodes(startNodeName);
      for (int i=0; i < childNodes.length; ++i) 
      {
        String node = childNodes[i];
        String breadcrumb = createBreadcrumb(targetNodeName, node);
        // When breadcrumb is an empty string, this path was a dead end. Otherwise, we can start unwinding the stack to build the breadcrumb.
        if (breadcrumb != "")
        {
          return startNodeName + " > " + breadcrumb;
        }
      }
    }

    // If this node is not a match and we found no match in the children, then no match was found. Return empty string.
    return "";
  }
  
  
  static String[] getMenuChildNodes(String nodeName)
  {
    if (menu.containsKey(nodeName))
    {
      return menu.get(nodeName);
    }
    else return new String[0];
  }
  
  
  private static HashMap<String, String[]> menu;
  private static void setupMenuNodeMap()
  {
    menu = new HashMap<String, String[]>();

    String[] booksNode = { "Classics", "Non-Fiction", "Sci-Fi" };
    menu.put("Books", booksNode);

    String[] classicsNode = { "Treasure Island", "The Great Gatsby", "Moby Dick" };
    menu.put("Classics", classicsNode);

    String[] nonFictionNode = { "Birthday Letters", "The Selfish Gene", "Life on the Mississippi" };
    menu.put("Non-Fiction", nonFictionNode);

    String[] sciFiNode = { "Star Wars", "Star Trek", "Ender's Game" };
    menu.put("Sci-Fi", sciFiNode);
  }
}