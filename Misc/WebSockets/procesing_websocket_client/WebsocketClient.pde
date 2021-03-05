import java.lang.reflect.Method;
import java.net.URI;
import org.eclipse.jetty.client.HttpClient;
import org.eclipse.jetty.util.ssl.SslContextFactory;
import org.eclipse.jetty.websocket.client.ClientUpgradeRequest;
import org.eclipse.jetty.websocket.client.WebSocketClient;
import processing.core.PApplet;

/**
 * 
 * @author Lasse Steenbock Vestergaard
 *
 * Class for creating websocket client connections to any websocket server. Sub-protocols have not yet been implemented, and it's therefore only possible to connect to regular websocket servers. 
 *
 */
public class WebsocketClient {
  private Method webSocketEvent;
  private Method webSocketEventBinary;
  private WebsocketClientEvents socket;

  /**
   *
   * Initiating the client connection
   *
   * @param parent Processing's PApplet object
   * @param endpointURI The URI to connect to Ex. ws://localhost:8025/john
   */
  public WebsocketClient(PApplet parent, String endpointURI) {
    this(parent, parent, endpointURI, new StringList());
  }

  /**
   *
   * Initiating the client connection
   *
   * @param parent Processing's PApplet object
   * @param endpointURI The URI to connect to Ex. ws://localhost:8025/john
   * @param headers A list of custom headers to attach to the WS request, like "User-Agent:Processing"
   */
  public WebsocketClient(PApplet parent, String endpointURI, StringList headers) {
    this(parent, parent, endpointURI, headers);
  }

  /**
   * More flexible constructor in case you don't want callbacks called
   * in your PApplet but in a different class. Use this if you are
   * instantiating WebsocketClient in a class.
   *
   * @param parent Processing's PApplet object
   * @param callbacks The object implementing .webSocketEvent()
   * @param endpointURI The URI to connect to Ex. ws://localhost:8025/john
   * @param headers A list of custom headers to attach to the WS request, like "User-Agent:Processing"
   */
  public WebsocketClient(PApplet parent, Object callbacks,
               String endpointURI, StringList headers) {
    parent.registerMethod("dispose", this);

    try {
      webSocketEvent = callbacks.getClass().getMethod("webSocketEvent",
          String.class);
      webSocketEventBinary = callbacks.getClass().getMethod("webSocketEvent", byte[].class, int.class, int.class);
    } catch (Exception e) {
      // no such method, or an error.. which is fine, just ignore
    }

    WebSocketClient client = null;

    if(endpointURI.startsWith("wss")) {
      SslContextFactory ssl = new SslContextFactory();
      client = new WebSocketClient(ssl);
    } else {
      client = new WebSocketClient();
    }

    try {
      socket = new WebsocketClientEvents(callbacks, webSocketEvent,
          webSocketEventBinary);
      client.start();
      URI echoUri = new URI(endpointURI);
      ClientUpgradeRequest request = new ClientUpgradeRequest();

      // If headers are present, set them 
      for (String header : headers)
      {
        String[] h = header.split(":");
        if (h.length != 2) 
        {
        throw new Exception("Incorrectly formatted header \"" + header + 
          "\", please use \":\" to separate key and value, " +
          "as in \"User-Agent:Processing\"");
        }
        request.setHeader(h[0], h[1]);
      }

      client.connect(socket, echoUri, request);
      socket.getLatch().await();

    } catch (Throwable t) {
      t.printStackTrace();
    }
  }

  /**
   *
   * Send message to the websocket server. At a later stage it should be possible to send messages to specific clients connected to the same server
   *
   * @param message The message to send
   */
  public void sendMessage(String message){
    socket.sendMessage(message);
  }

  public void sendMessage(byte[] data){
    socket.sendMessage(data);
  }
  
  public void dispose(){
    // Anything in here will be called automatically when 
      // the parent sketch shuts down. For instance, this might
      // shut down a thread used by this library.
  }
}
