#include <SoftwareSerial.h>
#define GATE 11
float anValue;
float tempC;
int tempPin= 0; // sensor output pin 
int message = 0; // This will hold one byte of the serial message
void setup() {
  // put your setup code here, to run once:
  pinMode(GATE,OUTPUT);
  digitalWrite(GATE,LOW);
 Serial.begin(9600); // opens serial port to communicate with temp sensor
 
}

void loop() {
  // put your main code here, to run repeatedly:
  anValue = analogRead(tempPin);
  tempC = (5.0*anValue*100.0)/1024.0;
  Serial.println("t"+String(tempC));

 
  if (Serial.available() > 0) { // Check to see if there is a new message
message = Serial.read(); // Put the serial input into the message

if (message == 'r'){ // If a capitol A is received
//LED = 255; // Set LED to 255 (on)
analogWrite(GATE,255);
//Serial.println("LED on"); // Send back LED on
}
if (message == 'l'){ // If a capitol A is received
//LED = 255; // Set LED to 255 (on)
analogWrite(GATE,128);

//Serial.println("LED on"); // Send back LED on
}
if (message == 's'){ // If a lowercase a is received
  analogWrite(GATE,0);
//LED = 0; // Set LED to 0 (off)
//Serial.write("ORANGE");
//Serial.println("LED off"); // Send back LED off
}
}
  
delay(1000);
  
  /*delay(5000);
  analogWrite(GATE,255);
  delay(10000);
  analogWrite(GATE,50);
  delay(8000);
  analogWrite(GATE,0);*/
}
