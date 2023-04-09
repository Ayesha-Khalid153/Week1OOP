#include <iostream>
using namespace std;
int calculations(int age,int toysPrice,int machinePrice);
main()
{
	int age;
	int machinePrice;
	int toyPrice;
	int result;
	int finalAmount;
	cout<<"Enter the age of lilly[1 to 77]: ";
	cin>>age;
	cout<<"Enter the price of machine[1 to 10000]= ";
	cin>>machinePrice;
	cout<<"Enter the price of the toys sold[0 to 40]: ";
	cin>>toyPrice;
	
	result =calculations(age,toyPrice,machinePrice);
	if(result > 0)
		{
			cout<<"YES! you have "<<result<<"amount left.";
		}
		if(result < 0)
		{
			result =-(result);
			cout<<"NO! you have "<<result<<"amount needed.";
		}
	
}
int calculations(int age,int toysPrice,int machinePrice)
{
	int temp=10;
	int evenMoney=0;
	int noOfEven=0;
	int finalAmount;
	int noOfOdd=0;
	int oddMoney=0;
	int totalAmount;
	
		if(age%2 == 0)
		{
			noOfEven=age/2;
			noOfOdd=noOfEven;	
		}
		if(age%2 != 0)
		{
			noOfOdd = age/2+1;
			noOfEven = age/2;	
		}
		for(int idx=1;idx<=noOfEven;idx++)
		{
			evenMoney = evenMoney + temp;
			temp = temp + 10;
		}
		
	evenMoney = evenMoney - noOfEven;
	oddMoney= noOfOdd * toysPrice;
	totalAmount = evenMoney + oddMoney;
	finalAmount = totalAmount - machinePrice;
	return finalAmount;
}
