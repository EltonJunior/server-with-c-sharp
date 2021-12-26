using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

class ServidorHttp
{
  /// The Controller is responsible to listen the server port
  /// and wait some type of requests connection TCP
  private TcpListener Controller {get; set;}

  /// the property PORT will have the number of port will be running
  /// in this example, it will use the port 8080
  private int Port {get; set;}

 /// this property QTOFREQUESTS will help to figure out if all 
 /// request has been lost. It will count the requests. 
  private int QtofRequests{get;set;}


  ///<summary>
  ///This constructor has the optional parameter named port
  ///that already has the patter value 8080, Its mean that 
  ///if this constructor was called withoud pass any parameter 
  ///it will assume the 8080 value as port defult, note that
  ///argument port will pass the value to Port
  ///
  ///this Constructor also has the try/catch test. 
  ///on the try first it was created a new object from type Listener
  ///that will listening the IPAddres 127.0.0.1, that is machine local
  ///ip address at port 8080, after that it will be initialized Listening
  ///port 8080 at ip 127.0.0.1. after success started it will display 2 message
  ///the port that the server is running to and how to running it at browser. 
  ///</summary>
  ///<param name="port">The value of server port it is as default the 8080</param>
  ///<return>the Start of server at the port specificate in the port argument</return>
  ///<exception cref="Exception">
  ///this will have the general exception, if the serve got some error when 
  ///try start itself.
  public ServidorHttp(int port = 8080)
  {
    this.Port = port;
    try
    {
      this.Controller = new TcpListener(IPAddress.Parse("127.0.0.1"),this.Port);
      this.Controller.Start();
      Console.WriteLine($"Serve HTTP running at {this.Port}.");
      Console.WriteLine($"To Access, type at browser: http://localhost:{this.Port}.");
    }
    catch(Exception e)
    {
      Console.WriteLine($"Error to Start-up the Serve at port {this.Port}:\n{e.Message}");
    }
  }

  ///<summary>
  ///this function will await for new requests and each request will create a object type 
  ///SOCKET, this object is commun communication in all languages that allows to confirm 
  ///the connection request arrive and answer it according to type of requirement. 
  ///
  ///this function is ASYNC and inside it has a while that will await the arrives 
  ///news requests. Each iteration of SOCKET method wait a request and when this
  ///request is detected its RETURN the object SOCKET called here of CONNECTION.
  ///Those SOCKET object has the data from requestand allows it return the answer to
  ///requestor that is, in this case, the browser. As soon as it connect to browser
  ///starts count the requests. 
  ///<returns>SOCKET object</returns> 
  private async Task AwaitRequests()
  {
    while(true)
    {
      Socket connection = await this.Controller.AcceptSocketAsync();
      this.QtofRequests++;
    }
  }

  ///<summary>
  ///This Method will process the resquests, it will receive the Socket and 
  ///numbers that correspond to connection. this method is used inside of 
  ///while in each new connection.
  ///</summary>
  ///<param name="connection" type="Socket"></param>
  ///<param name="requestNumber" type="int">correspond to connection</param>
  ///<returns type=""></returns>
  private void ProcessRequest(Socket connection, int requestNumber)
  {
    Console.WriteLine($"Processing request #{requestNumber}...\n");
  }
}