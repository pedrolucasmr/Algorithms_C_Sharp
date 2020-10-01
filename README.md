# Algorithms_C_Sharp
So, i decided to try out some sorting algorithms in C#. The idea is to explain how each one of the algorithms works and how complex in Time and Space they are. Also, later in the development, i decided to implement some Python to create charts and comparisions between the algorithms.

First of all, we have the NumberGenerator class that generates random doubles so we do not need to enter them manually into the algorithms. This static class also generate random number quantities, so the number of doubles generated and given to the algorithms are also random(although within limits). The last method gives a small array, with a fixed lenght of 11 doubles, used mainly for initial tests of the algorithms.

The informations of each algorithm run, including it's time results, are stored in a MySQL database. Every operation in the DB is done through stored procedures, the application never touching the tables.

Using Python, information about the runs are read from the database and used in the creation of comparision charts(WIP). The charts compare the time results of each algorithm and show which one performs better in pre-defined amounts of entries. Also, charts for comparing individual algorithms are created, showing how the given algorithm performs with the different amounts of entries. All the calculations and operations necessary for the creation of charts are done in Python.

Now, let's talk about the algorithms. For the purpose of this mini-project, each algorithm has it's own class, all of them inheriting from a interface. The Interface has six properties: the name of the algorithm(for example, "bubble sort"), the space and time notations, the start of the current run and it's end, and from that values it calculates the TotalTime of the run. It has four methods: a setter, a sort method that receives and returns a array of doubles, a different version of the sort method that writes the information about the algorithm and the results in a text file and a unitary test of the sort method, that tests if the array is really sorted. 

**Bubble Sort**
Data Structure: array
A basic one, it swaps the adjacent values if they are in the wrong order. The algorithm does it over and over again until all the values are in the right position. Normally, the algorithm runs through the entire array one last time to garentee that every value is in order, we use a variable to prevent this and save some time. Basically, the variable is set to true if a value was swaped and if it's not, the variable is set to false. When a loop ends, if the variable's value is false, the algorithm stops and returns the result array. This algorithm is pretty slow, having a notation of O(n^n), but has a good space notation of O(1). 


**Selection Sort**
Data Structure: array
Another simple algorithm, Selection Sort tends to be faster than Bubble Sort, althoug still having a time notation of O(n^n). The space notation is O(1). What Selection Sort does is divide the array in two parts, one already sorted and other to be sorted, it picks the first element of the unsorted part and stard comparing it to the next entries, when of them is smaller than the current value, it picks it up and go on with the comparisons. When there's no smaller value, the algorithm puts the current value in the next position of the sorted part of the array and picks the first value of the unsorted part, repeating the process over and over again until the array is completely sorted.


**Quick Sort**
Data Structure: array
This is a more advanced sorting algorithm and one of the most used in general. It is fast, having a time notation of O(n*log n). It's space notation is O(log n).
Quick Sort is a recursive algorithm, what means that the function/method is called inside itself. It works by picking a element as pivot, the picking method may vary from implementation to implementation and in this one we use the middle element of the array. After that, it places the chosen element in it's correct position using comparisions. Then the recursion begins: the algorithm will divide the array in two subarrays(one on the left of the pivot and one on the right) and call the method once again for each of them. It will do this until the array is sorted. Quick Sort, as said before, is a fast algorithm and this makes it one of the most used for general purposes, as it can sort arrays with even a million values in a second or two. When working with large amounts of data store externaly, Merge sort tends to be preferred over Quick Sort. Quick Sort is a divide and conquer algorithm.


**Merge Sort**
Data Structure: array
Another algorithm based on recursion, Merge Sort is also a fast one, having a o(n*log n) time notation, but is more space efficient with it's notation of O(n). Mainly used for sorting huge amounts of data in external storage, it is algo one of the most used sorting algorithms out there. It works by dividing the given array into halves until each one has only one value. Then, it merges the subarrays, putting them in order. This sorts the array, as each one of the subarrays is put in the right position during the merging. Merge Sort is also a divide and conque algorithm. 
