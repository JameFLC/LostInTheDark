#define slot1 0
const int slots[] = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

void delaySec(float s) {
  delay(s * 1000);
}

void testReedSwitch() {
  int rsStatus1 = 0;
  int rsStatus[12] = {0};
  int activeCount = 0;
  
  // Read all the reed switche's slots
  for (int i=0; i<13; i++) {
    rsStatus1 = digitalRead(slot1);
    rsStatus[i] = digitalRead(slots[i]);

    if (rsStatus1 == 0)
      Serial.println(1);
    else if (i < 12 && rsStatus[i] == 0)
      Serial.println(slots[i]);
    else
      activeCount++;
  }

  if (activeCount == 13)
    Serial.println(0);

  delaySec(0.1);
}


void setup() {
 	//Init Serial USB
 	Serial.begin(9600);
 	Serial.println(F("Initialize System"));
  
 	// Init rs pins
  for (int i=0; i<13; i++)
    pinMode(slots[i], INPUT_PULLUP);
}

void loop() {
  testReedSwitch();
}