#BoxFactory 
Project focusing on Data structure using C# application.

### Concept 
 You own a Box Factory , you have your storage filled with boxes of different hights  and bases.
A customer comes with a request for a specific box and it's quantity 
you would use this application to find out if you can meet his requirements , If not the app will suggest the closes boxes to meet said requirements. 

### Implementation 
to make an affective search though your boxes let's organize to a Binary Tree. 
Now to set the stage let's call the base 'x' and the hight 'y', x and y are measurements and so they have to be of type double .
Back to our Binary Tree,  each Node will have to contain the base (x) and ... another Binary Tree for the different Hights (y) and boxes quantity. 
exampleNode:
[insert NodeImg]

### The Binary Tree Search
by now you know how the Node looks,
let's go and check the Tree as a whole :
[insert TreeImg]

in this Img you can see the root Node and 2 of its children , one bigger and one smaller.  
When we search for a specific x value we cut the search by half each level we go down and the same goes once we found the base(x) we go over the Binary Tree of y .


##to run
 Clone repository 
in the Folder , double click 
the .sln file .
done 