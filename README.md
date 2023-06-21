# QHEAP1

This question is designed to help you get a better understanding of basic heap operations.

There are 3 types of query:

"1 v" - Add an element v to the heap.
"2 v" - Delete the element v from the heap.
"3" - Print the minimum of all the elements in the heap.
NOTE: It is guaranteed that the element to be deleted will be there in the heap. Also, at any instant, only distinct elements will be in the heap.

Input Format

The first line contains the number of queries, Q.
Each of the next Q lines contains one of the 3 types of query.

Constraints
1 <= Q <= 10^5
-10^9 <= V <= 10^9

Output Format

For each query of type 3, print the minimum value on a single line.

Sample Input

STDIN       Function
-----       --------
5           Q = 5
1 4         insert 4
1 9         insert 9
3           print minimum
2 4         delete 4
3           print minimum
Sample Output

4  
9 
Explanation

After the first 2 queries, the heap contains {4, 9}. Printing the minimum gives 4 as the output. Then, the 4th query deletes 4 from the heap, and the 5th query gives 9 as the output.