
int a[20];

void main(int n) { 
  int i; 
  i = 0; 
  int f; 
  f = 0;
  square(n, a);
  while (i <= n) 
  {
    f = f + a[i];
    i = i+1;
  }
  print(f);
  println;
}

void square(int len, int a[]) {
  int i;
  i = 0; 
  while (i <= len) 
  { 
    a[i] = (i*i);
    i = i+1;
  }
}