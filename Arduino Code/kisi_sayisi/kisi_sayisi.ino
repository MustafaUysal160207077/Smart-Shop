
#include<Servo.h>
int trigPin = 4; /* Sensorun trig pini Arduinonun 6 numaralı ayağına bağlandı */
int echoPin = 7;  /* Sensorun echo pini Arduinonun 7 numaralı ayağına bağlandı */


long sure;
long uzaklik;
int kisi = 0;
int hirsiz;
Servo motor;
void setup(){
  pinMode(trigPin, OUTPUT); /* trig pini çıkış olarak ayarlandı */
  pinMode(echoPin,INPUT); /* echo pini giriş olarak ayarlandı */
  pinMode(6,INPUT);
  pinMode(5,OUTPUT);
   motor.attach(11); 
  Serial.begin(9600); /* Seri haberlesme baslatildi */
}
char message;  
void loop()
{

 if (Serial.available() > 0) {
  message = Serial.read();   // seri mesaji msj değişkenine aktardık

  if(message == 'o'){                   
   motor.write(80); 
  }
  if(message=='c'){
    motor.write(0); 
  }
  if(message=='p'){
     digitalWrite(5,HIGH);
  }
  if(message=='a'){
     digitalWrite(5,LOW);
  }
 }

  hirsiz = digitalRead(6);
  if(hirsiz==HIGH)
   Serial.println("h");
  // digitalWrite(5,HIGH);
 
 
  digitalWrite(trigPin, LOW); /* sensör pasif hale getirildi */
  delayMicroseconds(5);
  digitalWrite(trigPin, HIGH); /* Sensore ses dalgasının üretmesi için emir verildi */
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);  /* Yeni dalgaların üretilmemesi için trig pini LOW konumuna getirildi */ 
  sure = pulseIn(echoPin, HIGH); /* ses dalgasının geri dönmesi için geçen sure ölçülüyor */
  uzaklik= sure /29.1/2; /* ölçülen sure uzaklığa çevriliyor */            
  if(uzaklik > 200)
    uzaklik = 200;

    if(uzaklik>1 && uzaklik<10){
        kisi++;
       Serial.println("k"+String(kisi));
       //Serial.println("\n");
       //Serial.println("t30");
    }
  delay(1000);
}
