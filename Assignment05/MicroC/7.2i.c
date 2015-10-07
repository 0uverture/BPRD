/*void arrsum(int n, int arr[], int *sump){
	int i;
	i = 0;
	while (i < n){
		*sump = *sump + arr[i];
		i = i + 1;
	}
}*/

void arrsum(int n, int arr[], int *sump){
	int i;
	for (i = 0; i < n; ++i){
		*sump = *sump + arr[i];
	}
}

void main() {
	int* arr[4];
	arr[0] = 7;
	arr[1] = 13;
	arr[2] = 9;
	arr[3] = 8;
	int sump;	
	sump = 0;
	arrsum(4, arr, &sump);
	print(sump);
	println;
}
