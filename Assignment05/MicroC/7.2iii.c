/*void histogram(int n, int ns[], int max, int freq[]){
	int i;
	i = 0;
	while (i < n){
		freq[ns[i]] = freq[ns[i]] + 1;
		i = i + 1;		
	}
}

void main() {

	int arr[7];
	arr[0] = 1;
	arr[1] = 2;
	arr[2] = 1;
	arr[3] = 1;
	arr[4] = 1;
	arr[5] = 2;
	arr[6] = 0;
	int max;
	max = 3;
	int freq[4];

	int i;
	i = 0;
	while (i <= max){
		freq[i] = 0;
		i = i + 1;
	}

	histogram(7, arr, max, freq);

	i = 0;
	while (i <= max){
		print(freq[i]);
		println;
		i = i + 1;
	}
}*/

void histogram(int n, int ns[], int max, int freq[]){
	int i;
	for (i = 0; i < n; i = i + 1){
		freq[ns[i]] = freq[ns[i]] + 1;
	}
}

void main() {

	int arr[7];
	arr[0] = 1;
	arr[1] = 2;
	arr[2] = 1;
	arr[3] = 1;
	arr[4] = 1;
	arr[5] = 2;
	arr[6] = 0;
	int max;
	max = 3;
	int freq[4];

	int i;
	for (i = 0; i <= max; i = i + 1){
		freq[i] = 0;
	}

	histogram(7, arr, max, freq);

	for (i = 0; i <= max; i = i + 1){
		print(freq[i]);
		println;
	}
}

