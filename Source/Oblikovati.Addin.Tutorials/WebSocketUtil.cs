using System.Globalization;
using System.Net.WebSockets;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;

namespace Oblikovati.Addin.Tutorials;

public class WebSocketUtil
  {
    private WebSocket _webSocket;
    private string _hostPort = "ws://localhost:9001";
    private WebSocketUtil.OnOpenSocketDelegate _onOpenSocketFunction;
    private WebSocketUtil.OnMessageSocketDelegate _onMessageSocketFunction;
    private WebSocketUtil.OnErrorSocketDelegate _onErrorSocketFunction;
    private WebSocketUtil.OnCloseSocketDelegate _onCloseSocketFunction;
    private bool _debugging;

    public WebSocket TheSocket => this._webSocket;

    public bool IsInitialized { get; private set; }

    public WebSocketUtil()
    {
      this._webSocket = (WebSocket) null;
      this.IsInitialized = false;
    }

    public void Connect(bool bUseAsync, string useThisHostPort = null, string connectionParameters = null)
    {
      try
      {
        int numReceived = 0;
        if (!useThisHostPort.IsNullOrEmpty())
          this._hostPort = useThisHostPort;
        if (connectionParameters == null)
          this._webSocket = new WebSocket(this._hostPort, Array.Empty<string>());
        else
          this._webSocket = new WebSocket(this._hostPort, new string[1]
          {
            connectionParameters
          });
        this._webSocket.OnOpen += (EventHandler) ((sender, e) =>
        {
          bool flag = this._webSocket.Ping();
          this.IsInitialized = true;
          if (this._onOpenSocketFunction != null)
            this._onOpenSocketFunction();
          if (!this._debugging)
            return;
          int num = (int) MessageBox.Show("Opened, ping was: " + flag.ToString());
          Console.WriteLine("Opened");
        });
        this._webSocket.OnMessage += (EventHandler<WebSocketSharp.MessageEventArgs>) ((sender, e) =>
        {
          ++numReceived;
          string text = "";
          if (this._debugging)
            text = "Total received so far is: " + numReceived.ToString();
          //if (e.Type == Opcode.Text)
          //{
          //  if (this._onMessageSocketFunction != null)
          //    this._onMessageSocketFunction(e.Data);
          //  if (this._debugging)
          //    text = text + " Data received is: " + e.Data;
          //}
          //else if (e.Type == Opcode.Binary)
          //{
          //  int num1 = (int) MessageBox.Show("Websocket code is Binary, not handled.");
          //}
          if (!this._debugging)
            return;
          int num2 = (int) MessageBox.Show(text);
          Console.WriteLine("Received: " + e.Data);
        });
        this._webSocket.OnError += (EventHandler<WebSocketSharp.ErrorEventArgs>) ((sender, e) =>
        {
          if (this._onErrorSocketFunction != null)
            this._onErrorSocketFunction(((object) e).GetType());
          if (!this._debugging)
            return;
          string text = "Error: " + e.Message;
          int num = (int) MessageBox.Show(text);
          Console.WriteLine(text);
        });
        this._webSocket.OnClose += (EventHandler<CloseEventArgs>) ((sender, e) =>
        {
          if (this._onCloseSocketFunction != null)
            this._onCloseSocketFunction();
          if (!this._debugging)
            return;
          int num = (int) MessageBox.Show("Closed!  Don't know why!");
          Console.WriteLine("Closed!  Don't know why!");
        });
        if (bUseAsync)
          this._webSocket.ConnectAsync();
        else
          this._webSocket.Connect();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public void Close(bool bUseAsync)
    {
      if (bUseAsync)
        this._webSocket.CloseAsync();
      else
        this._webSocket.Close();
    }

    public void SetOnOpenSocketFunction(WebSocketUtil.OnOpenSocketDelegate openMethod) => this._onOpenSocketFunction = new WebSocketUtil.OnOpenSocketDelegate(openMethod.Invoke);

    public void SetOnMessageSocketFunction(
      WebSocketUtil.OnMessageSocketDelegate messageMethod)
    {
      this._onMessageSocketFunction = new WebSocketUtil.OnMessageSocketDelegate(messageMethod.Invoke);
    }

    public void SetOnErrorSocketFunction(WebSocketUtil.OnErrorSocketDelegate errorMethod)
    {
      if (errorMethod == null)
        this._onErrorSocketFunction = (WebSocketUtil.OnErrorSocketDelegate) null;
      else
        this._onErrorSocketFunction = new WebSocketUtil.OnErrorSocketDelegate(errorMethod.Invoke);
    }

    public void SetOnCloseSocketFunction(WebSocketUtil.OnCloseSocketDelegate closeMethod) => this._onCloseSocketFunction = new WebSocketUtil.OnCloseSocketDelegate(closeMethod.Invoke);

    private static void MySuccess(bool wasSent)
    {
    }

    public void SendEventMessage(bool bUseAsync, PacketBase eventPacket)
    {
      try
      {
        string data = JsonParser.Stringify((object) eventPacket);
        if (bUseAsync)
          this._webSocket.SendAsync(data, new Action<bool>(WebSocketUtil.MySuccess));
        else
          this._webSocket.Send(data);
        eventPacket = (PacketBase) null;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public void SendGenericMessage(bool bUseAsync, string dataString)
    {
      try
      {
        if (bUseAsync)
        {
          Action<bool> action = (Action<bool>) null;
          this._webSocket.SendAsync(dataString, action);
        }
        else
          this._webSocket.Send(dataString);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public void SendHeartBeat(bool bUseAsync)
    {
      try
      {
        DateTime dateTime = DateTime.Today;
        dateTime = dateTime.ToLocalTime();
        string str = dateTime.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        string data = JsonParser.Stringify((object) new EventPacket()
        {
          EventName = "heartbeat",
          EventData = str
        });
        Action<bool> action = (Action<bool>) null;
        if (bUseAsync)
          this._webSocket.SendAsync(data, action);
        else
          this._webSocket.Send(data);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }

    public delegate void OnOpenSocketDelegate();

    public delegate void OnMessageSocketDelegate(string stuff);

    public delegate void OnErrorSocketDelegate(Type errorType);

    public delegate void OnCloseSocketDelegate();
  }