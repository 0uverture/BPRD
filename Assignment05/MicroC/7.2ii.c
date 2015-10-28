int a[20];

/*void square(int len, int a[]) {
	int i;
	i = 0;
	while (i <= len)
	{
		a[i] = (i*i);
		i = i + 1;
	}
}

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
}*/

void square(int len, int a[]){
	int i;
	for (i = 0; i <= len; i = i + 1){
		a[i] = (i * i);
	}
}

void main(int n) {
	int i;
	int f;
	f = 0;
	square(n, a);
	for (i = 0; i <= n; i = i + 1){
		f = f + a[i];
	}
	print(f);
	println;
}