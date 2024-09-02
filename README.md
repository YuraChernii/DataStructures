![](media/image1.png){width="6.5in" height="4.229861111111111in"}

![](media/image2.png){width="6.5in" height="4.80625in"}

Static array --

1.  new\[10\];

2.  We should specify capacity of array;

Dynamic array --

1.  new List();

2.  We should not specify capacity of array. It create array with
    capacity with 4 and if capacity is not enough it creates new array
    with doubled capacity;

Linked and Doubled Linked List --
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/DoubleLinkedList.cs>)

Stack -- implemented by LinkedList. Has push, pop, peek methods.
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/Stack.cs>)

Queue -- implemented by LinkedList. Has enqueue, dequeue, peek methods.

![](media/image3.png){width="3.517341426071741in"
height="2.3099464129483813in"}

Priority Queue (Heap) -- tree (root should have max or min value).
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/PriorityQueue.cs>)  
A priority queue is useful in scenarios where you need to manage a
collection of items that each have a priority, and you often need to
retrieve or remove the item with the highest (or lowest) priority

![](media/image4.png){width="2.5352416885389326in"
height="1.8142147856517936in"}![](media/image5.png){width="2.5500010936132984in"
height="1.7803685476815398in"}

Binary tree -- has only two children.

We implement heap using Array:  
![](media/image6.png){width="4.727272528433946in"
height="3.3022134733158355in"}

![](media/image7.png){width="3.7612674978127734in"
height="2.717677165354331in"}

Indexed Priority Queue:
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/IndexedPriorityQueue.cs>)

The Indexed Priority Queue operates like a standard priority queue but
includes an additional array to track the indexes of inserted values.
This allows for O(1) time access to elements by their index and enables
quick updates or removals, with the actual operation time being O(log n)
due to the need to reorganize the priority queue.

![](media/image8.png){width="3.192474846894138in"
height="1.904569116360455in"}

Union Find:
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/UnionFind.cs>)

Dynamic Connectivity in a Social Network: Suppose you are building a
social network application where users can send friend requests to each
other. You can use Union-Find to keep track of which users are in the
same connected group (i.e., can reach each other through a series of
friend connections). When two users become friends, you perform a Union
operation to merge their friend groups. When users want to know if they
are connected (directly or indirectly), you perform a Find operation.

![](media/image9.png){width="3.342412510936133in"
height="2.371469816272966in"}

Binary Tree: parent has not more then two children.

![](media/image10.png){width="2.61300634295713in"
height="1.50582895888014in"}![](media/image11.png){width="3.681161417322835in"
height="2.0175590551181104in"}

![](media/image12.png){width="3.0851148293963253in"
height="1.8029461942257219in"} it is bad, that is why we use Balanced
Tree

Hash Tables:

![](media/image13.png){width="5.210935039370079in"
height="3.3525918635170604in"}![](media/image14.png){width="5.156456692913386in"
height="3.119767060367454in"}

Two implementations:

1.  **Separate chaining**
    (<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/HashTables/HashTableWithSeperateChaining.cs>)

2.  **Open Addressing**

![](media/image15.png){width="2.8781813210848646in"
height="2.0654636920384952in"}![](media/image16.png){width="3.2061089238845146in"
height="2.080984251968504in"}

Several types of Open Addressing:

1.  Linear probing
    (<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/HashTables/HashTableWithLinearProbing.cs>)

2.  Quadric probing

3.  Double hashing

Fenwick Tree (Binary Indexed Tree):
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/FenwickTree.cs>)

![](media/image17.png){width="3.6141633858267714in"
height="2.096292650918635in"}![](media/image18.png){width="3.4205446194225724in"
height="2.638132108486439in"}![](media/image19.png){width="2.8348775153105863in"
height="2.0843602362204723in"}

![](media/image20.png){width="4.087667322834646in"
height="3.002863079615048in"}

Suffix Arrays:

![](media/image21.png){width="3.4138648293963256in"
height="2.0173173665791775in"}

Longest Common Prefix (LCP) array:

![](media/image22.png){width="3.9760640857392824in"
height="3.058934820647419in"}

Problem to solve:

![](media/image23.png){width="6.5in" height="0.9993055555555556in"}

![](media/image24.png){width="3.7657556867891513in"
height="2.5780938320209974in"}

![](media/image25.png){width="2.740748031496063in"
height="1.4017049431321085in"}

![](media/image26.png){width="6.5in" height="4.076388888888889in"}

Longest Common Substring (LCS):

is about finding the longest sequence of characters that appear in both
of two given strings, in the same order, but not necessarily
consecutively. Use Dynamic Programming to implement.  
For example:  
X = \"AXY\"  
Y = \"AYZ\"  
Result: \"AY\"

Balanced Binary Search Tree:
(<https://github.com/YuraChernii/DataStructures/blob/master/DataStructures/DataStructures/AVLTree.cs>)

![](media/image27.png){width="4.609303368328959in"
height="2.335676946631671in"}

![](media/image28.png){width="3.2263232720909887in"
height="2.267387357830271in"}

![](media/image29.png){width="3.266972878390201in"
height="2.0746675415573055in"}![](media/image30.png){width="3.02332239720035in"
height="2.1883562992125984in"}

![](media/image31.png){width="3.384818460192476in"
height="1.9950896762904637in"}![](media/image32.png){width="3.075353237095363in"
height="1.990437445319335in"}![](media/image33.png){width="3.2622397200349957in"
height="1.9409623797025373in"}![](media/image34.png){width="3.2469728783902014in"
height="1.964834864391951in"}

![](media/image35.png){width="3.40202646544182in"
height="2.4014096675415573in"}![](media/image36.png){width="3.057303149606299in"
height="1.6547320647419073in"}  
![](media/image37.png){width="3.4670341207349082in"
height="2.8084448818897636in"}
