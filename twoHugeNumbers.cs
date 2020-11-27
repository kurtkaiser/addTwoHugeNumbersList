// Singly-linked lists are already defined with this interface:
// class ListNode<T> {
//   public T value { get; set; }
//   public ListNode<T> next { get; set; }
// }
//
ListNode<int> addTwoHugeNumbers(ListNode<int> a, ListNode<int> b) {

    ListNode<int> aTemp = null;
    ListNode<int> aPrev = null;

    ListNode<int> bTemp = null; 
    aTemp = a;
    bTemp = b;
    bool aNull = aTemp.next != null;
    bool bNull = bTemp.next != null;
    
    ListNode<int> aNext = aTemp.next;
   while(aTemp.next != null){
           aNext = aTemp.next;
           aTemp.next = aPrev;
           aPrev = aTemp;
           aTemp = aNext;
    }
    aTemp.next = aPrev;

    aPrev = null;
    while(bTemp.next != null){
           aNext = bTemp.next;
           bTemp.next = aPrev;
           aPrev = bTemp;
           bTemp = aNext;
    }
    bTemp.next = aPrev;
  
    // Result
    ListNode<int> result;// = new ListNode<int>();
    ListNode<int> pr = null;//new ListNode<int>();
    int add = 0;
    while(aTemp.next != null && bTemp.next != null){
           ListNode<int> r = new ListNode<int>();
           r.value = aTemp.value + bTemp.value + add;
           add = r.value/10000;
           if(add > 0){
               r.value %= 10000;
           }
           aTemp = aTemp.next;
           bTemp = bTemp.next;
           result = r;
           result.next = pr;
           pr = result;
    }
    
    ListNode<int> lastA = new ListNode<int>();
    lastA.value = aTemp.value + bTemp.value + add;
    add = lastA.value/10000;
    if(add > 0){
        lastA.value %= 10000;
    }
    result = lastA;
    result.next = pr;
    pr = result;
    
    // Clean up the loops, make a method instead of repeating for each list
    while(aTemp.next != null){
        aTemp = aTemp.next;
        ListNode<int> r = new ListNode<int>();
        r.value = aTemp.value + add;
        add = r.value/10000;
        if(add > 0){
            r.value %= 10000;
        }
        result = r;        
        result.next = pr;
        pr = result;
    }
    
    while(bTemp.next != null){
        bTemp = bTemp.next;
        ListNode<int> r = new ListNode<int>();
        r.value = bTemp.value + add;
        add = r.value/10000;
        if(add > 0){
            r.value %= 10000;
        }
        result = r;        
        result.next = pr;
        pr = result;
    }
    
    if(add > 0){
        ListNode<int> r = new ListNode<int>();
        r.value = add;
        result = r;
        result.next = pr;
    }

    return result;
}
