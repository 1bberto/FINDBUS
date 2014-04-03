#include<SoftwareSerial.h>
#include <string.h>
#include <ctype.h>
#include <math.h>;
SoftwareSerial ss(2, 3);
int ledPin = 13;
int byteGPS = -1;
char linea[300] = "";
char comandoGPR[7] = "$GPRMC";
int cont = 0;
int bien = 0;
int conta = 0;
int indices[13];
String Retorno;
String latitude;
String longitude;
String LatCondicao;
String LongCondicao;
char* temp;
void setup() {
  pinMode(ledPin, OUTPUT);       // Initialize LED pin
  // Serial monitor
  Serial.begin(9600);
  // baud rate for GPS - 38400 is prefered, but 4800 can also be used
  ss.begin(38400);
  // Initialize card
  for (int i = 0; i < 300; i++) { // Initialize a buffer for received data
    linea[i] = ' ';
  }
}
void loop() {
  digitalWrite(ledPin, HIGH);
  for (int i = 0; i <= 300; i++) { //
    linea[i] = ' ';
  }
  latitude = "";
  longitude = "";
  
  for (unsigned long start = millis(); millis() - start < 100;)
  {
    while (ss.available())
    {
      byteGPS = ss.read();
      linea[conta] = byteGPS;      // If there is serial port data, it is put in the buffer
      conta++;
    }
  }
  /*Serial.println(linea);*/
  // If the received byte is = to 13, end of transmission
  // note: the actual end of transmission is <CR><LF> (i.e. 0x13 0x10)
  digitalWrite(ledPin, LOW);
  cont = 0;
  bien = 0;
  // The following for loop starts at 1, because this code is clowny and the first byte is the <LF> (0x10) from the previous transmission.
  for (int i = 1; i < 7; i++) { // Verifies if the received command starts with $GPR
    if (linea[i] == comandoGPR[i]) {
      bien++;
    }
  }
  /*Serial.println(bien);*/
  if (bien == 5) {           // If yes, continue and process the data
    for (int i = 0; i < 300; i++) {
      if (linea[i] == ',') { // check for the position of the  "," separator
        // note: again, there is a potential buffer overflow here!
        indices[cont] = i;
        cont++;
      }
      if (linea[i] == '*') { // ... and the "*"
        indices[12] = i;
        cont++;
      }
    }
    /*Serial.println("");      // ... and write to the serial port
    Serial.println("");
    Serial.println("---------------");*/
    for (int i = 0; i < 12; i++) {
      /*switch (i) {
        //case 0 : Serial.print("Time in UTC (HhMmSs): "); break;
        case 1 : Serial.print("Status (A=OK,V=KO): "); break;
        case 2 : Serial.print("Latitude: "); break;
        case 3 : Serial.print("Direction (N/S): "); break;
        case 4 : Serial.print("Longitude: "); break;
        case 5 : Serial.print("Direction (E/W): "); break;
        case 6 : Serial.print("Velocity in knots: "); break;
        //case 7 : Serial.print("Heading in degrees: "); break;
        //case 8 : Serial.print("Date UTC (DdMmAa): "); break;
        //case 9 : Serial.print("Magnetic degrees: "); break;
        //case 10 : Serial.print("(E/W): "); break;
        //case 11 : Serial.print("Mode: "); break;
        //case 12 : Serial.print("Checksum: "); break;
      }*/
      for (int j = indices[i]; j < (indices[i + 1] - 1); j++) {        
        if (i == 1) {
          //Serial.print(linea[j + 1]);
          Retorno = Retorno + linea[j + 1];
        }else
        if (i == 2) {
          //Serial.print(linea[j + 1]);
          latitude = latitude + linea[j + 1];
        }else
        if (i == 3) {
          //Serial.print(linea[j + 1]);
          LatCondicao = LatCondicao + linea[j + 1];
        }else
        if (i == 4) {
          //Serial.print(linea[j + 1]);
          longitude = longitude + linea[j + 1];
        }else
        if (i == 5) {
          //Serial.print(linea[j + 1]);
          LongCondicao = LongCondicao + linea[j + 1];
        }else
          Serial.print("");
      }
    }
    char str[20];
    char *ptr;
    double ret;
    latitude.toCharArray(str, sizeof(str));    
    ret = strtod(str, &ptr);
    Serial.println("<Retorno>");
    Serial.print("<Status>");Serial.print(Retorno == "A" ? "OK" : "KO"); Serial.println("</Status>");
    Serial.print("<Latitude>");Serial.print(LatCondicao == "S" ? "-" : "");
    Serial.print(int(ret / 100) + (ret - (int(ret / 100) * 100)) / 60,20);
    Serial.println("</Latitude>");
    longitude.toCharArray(str, sizeof(str));    
    ret = strtod(str, &ptr);
    Serial.print("<Longitude>");Serial.print(LongCondicao == "W" ? "-" : "");
    Serial.print(int(ret / 100) + (ret - (int(ret / 100) * 100)) / 60,20);
    Serial.println("</Longitude>");
    Serial.println("</Retorno>");
  }
  conta = 0;
  cont = 0;
  for (int i = 0; i <= 300; i++) { //
    linea[i] = ' ';
  }  
}
