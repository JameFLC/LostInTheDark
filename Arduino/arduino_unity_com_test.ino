// Parameters
#define btnPin A0
#define ledPin 13


// Variables
int btnVal = 0;
bool btnIsPressed;
bool ledState = LOW;

void delaySec(float s) {
  delay(s * 1000);
}

void turnOn() {
  ledState = HIGH;
  digitalWrite(ledPin, ledState);
}

void turnOff() {
  ledState = LOW;
  digitalWrite(ledPin, ledState);
}

void testPushBtn() {
  // Read pushbutton
  btnVal = analogRead(btnPin);
  
  btnIsPressed = (btnVal < 200);
  
  if (btnIsPressed){
    Serial.println(F("Yeah"));
    turnOn();
  } else {
    turnOff();
  }
}


void setup() {
 	//Init Serial USB
 	Serial.begin(9600);
 	Serial.println(F("Initialize System"));
  
 	//Init btn & led
 	pinMode(btnPin, INPUT_PULLUP);
 	pinMode(ledPin, OUTPUT);
}

void loop() {
  testPushBtn();
}