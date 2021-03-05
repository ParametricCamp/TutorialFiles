// Global parameters
WebsocketClient wsc;
String SERVER_URL = "ws://simple-websocket-server-echo.glitch.me";
float EASING_SPEED = 0.05;
PVector pos = new PVector();
PVector target = new PVector();

void setup() {
  size(600, 400);
  
  StringList headers = new StringList();
  headers.append("User-Agent:Processing");
  
  wsc = new WebsocketClient(this, SERVER_URL, headers);
    
  background(0);
  noStroke();
}


void draw() {
  fill(0, 15);
  rect(0, 0, width, height);
  
  fill(255);
  circle(pos.x, pos.y, 20);
  
  // Ease position into target
  pos.x += EASING_SPEED * (target.x - pos.x);
  pos.y += EASING_SPEED * (target.y - pos.y);
}

void mousePressed() {
  setTarget(mouseX, mouseY);
  sendTargetToServer();
}

void setTarget(float tx, float ty) {
  target = new PVector(tx, ty);
}

void sendTargetToServer() {
  float nx = target.x / (float) width; 
  float ny = target.y / (float) height;
  
  JSONObject json = new JSONObject();
  json.setFloat("x", nx);
  json.setFloat("y", ny);
  
  wsc.sendMessage(json.toString());
}

void webSocketEvent(String msg) {
  println("Received: " + msg);
  JSONObject json = parseJSONObject(msg);
  float tx = width * json.getFloat("x");
  float ty = height * json.getFloat("y");
  
  setTarget(tx, ty);
}
