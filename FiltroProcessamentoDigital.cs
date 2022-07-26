//filtro 4 ordem butterworth ou cheb corte 100hz
//obter os coeficientes no octave
float f[] = {0,0,0,0,0};//guardar 5 valores de f
int ordem=4;//index do vetor
float y[] = {0,0,0,0,0};//5 valores de y

void setup() {
  Serial.begin(9600);//serial
  Serial.println("CLEARDATA"); // Comando para o Serial Plotter
  Serial.println("Sem_Filtro, Filtro"); // Inicia os titulos dos eixos do Serial Plotter.
}

void loop() {

  //Serial.println(analogRead(A0));
  Serial.println(filtro());//sinal filtrado
  delay(100);
}

float filtro(){
  int i = 4;
  //move os valores de f
 f[i-4] = f[i-3];
 f[i-3] = f[i-2];
 f[i-2] = f[i-1];
 f[i-1] = f[i];
 f[ordem] = analogRead(A0)*5/1024;
 
 //move os valores de y
 y[i-4] = y[i-3];
 y[i-3] = y[i-2];
 y[i-2] = y[i-1];
 y[i-1] = y[i];
  
 //funcao recursiva para filtrar o sinal
  y[i] = -3.8337*y[i-1]-5.5148*y[i-2]-3.5279*y[i-3] - 0.8468*y[i-4] + 0.9202*f[i]+3.6808*f[i-1]+5.5212*f[i-2]+3.6808*f[i-3]+0.9202*f[i-4];
  
  return(y[4]);
}