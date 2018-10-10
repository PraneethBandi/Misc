using Prep.Model;
using System;
using N = System.Collections.Generic;

namespace Prep
{
    public class LinkedListTopics
    {

        public N.List<int> maxset(N.List<int> A)
        {
            N.List<int> result = new N.List<int>();
            if (A == null)
                return result;

            if (A.Count == 0)
                return result;

            int fIndexCounter = 0, fIndex = -1;
            long fSum = 0;
            int sIndexCounter = 0, sIndex = -1;
            long sSum = 0;
            int counter = -1;
            var l = A.ToArray();

            for(int i = 0; i < l.Length; i++)
            {
                counter++;
                if (l[i] >= 0)
                {
                    sIndexCounter++;
                    sSum = sSum + l[i];
                    if (sIndex == -1)
                        sIndex = counter;

                }
                else if (sSum > fSum)
                {
                    fIndexCounter = sIndexCounter;
                    fSum = sSum;
                    fIndex = sIndex;

                    sIndex = -1;
                    sIndexCounter = 0;
                    sSum = 0;
                }
                else if (sSum == fSum && sIndexCounter > fIndexCounter)
                {
                    fIndexCounter = sIndexCounter;
                    fSum = sSum;
                    fIndex = sIndex;

                    sIndex = -1;
                    sIndexCounter = 0;
                    sSum = 0;
                }
                else if (sSum == fSum && sIndexCounter == fIndexCounter && sIndex < fIndex)
                {
                    fIndexCounter = sIndexCounter;
                    fSum = sSum;
                    fIndex = sIndex;

                    sIndex = -1;
                    sIndexCounter = 0;
                    sSum = 0;
                }
                else
                {
                    sSum = 0;
                    sIndex = -1;
                    sIndexCounter = 0;
                }
            }

            if (sIndex == -1 && fIndex == -1)
                return result;

            if (fIndex == -1)
            {
                fIndexCounter = sIndexCounter;
                fSum = sSum;
                fIndex = sIndex;
            }

            if (sSum > fSum)
            {
                fIndexCounter = sIndexCounter;
                fSum = sSum;
                fIndex = sIndex;

                sIndex = -1;
                sIndexCounter = 0;
                sSum = 0;
            }
            else if (sSum == fSum && sIndexCounter > fIndexCounter)
            {
                fIndexCounter = sIndexCounter;
                fSum = sSum;
                fIndex = sIndex;

                sIndex = -1;
                sIndexCounter = 0;
                sSum = 0;
            }
            else if (sSum == fSum && sIndexCounter == fIndexCounter && sIndex < fIndex)
            {
                fIndexCounter = sIndexCounter;
                fSum = sSum;
                fIndex = sIndex;

                sIndex = -1;
                sIndexCounter = 0;
                sSum = 0;
            }


            int index = fIndex;

            //Console.WriteLine(fIndexCounter);
            //Console.WriteLine(fIndex);
            for (int i = 1; i <= fIndexCounter; i++)
            {
                result.Add(l[index]);
                index++;
            }

            return result;

        }

        public  LinkedListNode FindLoopNode(LinkedListNode a)
        {
            if (a == null)
                return null;

            if (a.Next == null)
                return null;

            LinkedListNode sPointer = a;
            LinkedListNode fPointer = a;

            while (fPointer != null && fPointer.Next != null)
            {
                sPointer = sPointer.Next;
                fPointer = fPointer.Next.Next;

                if (sPointer == fPointer)
                    break;
            }

            if (fPointer == null)
                return null;

            if (fPointer.Next == null)
                return null;

            sPointer = a;

            while (sPointer != fPointer)
            {
                sPointer = sPointer.Next;
                fPointer = fPointer.Next;
            }

            return fPointer;
        }
        public LinkedListNode returnIth(LinkedList list, int i)
        {
            if (!(list != null && list.Head != null))
                return null;

            int counter = 1;
            var cur = list.Head;

            while(counter != i && cur != null)
            {
                counter++;
                cur = cur.Next;
            }

            if (counter < i)
                return null;

            var kNode = list.Head;
            while(cur.Next != null)
            {
                kNode = kNode.Next;
                cur = cur.Next;
            }

            return kNode;
        }

        public LinkedListNode RemoveDupes(LinkedList list)
        {
            if (!(list != null && list.Head != null))
                return null;

            var head = list.Head;


            var nextNode = head.Next;
            var prevNode = head;
            System.Collections.Generic.List<int> map = new System.Collections.Generic.List<int>();
            map.Add(head.Data);

            while(nextNode != null)
            {
                if(map.Contains(nextNode.Data))
                {
                    prevNode = DeleteNode(prevNode, nextNode);
                    nextNode = prevNode.Next;
                }
                else
                {
                    map.Add(nextNode.Data);
                    prevNode = nextNode;
                    nextNode = nextNode.Next;
                }
            }

            return head;

            var cur = list.Head;

            while (cur != null)
            {
                var next = cur.Next;
                var prev = cur;
                while(next != null)
                {
                    if (cur.Data == next.Data)
                    {
                        prev = DeleteNode(prev, next);
                        next = prev.Next;
                    }
                    else
                    {
                        prev = next;
                        next = next.Next;
                    }
                }
                cur = cur.Next;
            }

            return list.Head;
        }

        public LinkedListNode ReverseLinkedList(LinkedList list)
        {
            if (list == null)
                return null;

            if (list.Head == null)
                return null;

            var head = list.Head;
            var next = head.Next;
            head.Next = null;

            while(next != null)
            {
                var temp = next.Next;
                next.Next = head;
                head = next;
                next = temp;
            }

            return head;
        }

        public void printLinkedList(LinkedList list)
        {
            var temp = list.Head;
            while(temp != null)
            {
                Console.Write(temp.Data + " --> ");
                temp = temp.Next;
            }

            Console.WriteLine();
        }

        public LinkedList CreateLinkedList(int[] a)
        {
            LinkedList list = new LinkedList();
            list.Head = new LinkedListNode() { Data = a[0] };
            var temp = list.Head;

            for (int i = 1; i < a.Length; i++)
            {
                var node = new LinkedListNode() { Data = a[i] };
                temp.Next = node;
                temp = node;
            }

            return list;
        }

        public LinkedListNode DeleteNode(LinkedList list, int value)
        {
            if (!(list != null && list.Head != null))
                return null;

            if (list.Head.Data == value)
            {
                list.Head = list.Head.Next;
                return list.Head.Next;
            }
                
            var cur = list.Head.Next;
            var prev = list.Head;

            while(cur != null)
            {
                if (cur.Data == value)
                {
                    prev = DeleteNode(prev, cur);
                    break;
                }

                prev = cur;
                cur = cur.Next;
            }

            return list.Head;
        }

        public LinkedListNode DeleteNode(LinkedListNode prev, LinkedListNode deleteNode)
        {
            if (deleteNode == null)
                return prev;

            if (prev == null)
                return deleteNode.Next;

            prev.Next = deleteNode.Next;
            deleteNode = null;
            return prev;
        }

        public LinkedListNode SortLinkedList(LinkedList list)
        {
            if (!(list != null && list.Head != null))
                return null;

            var head = list.Head;
            LinkedListNode last = null;
            return MergeSort(head, last);
        }

        private LinkedListNode MergeSort(LinkedListNode first, LinkedListNode last)
        {
            if (first == last || first == null)
                return first;

            var middle = findMiddleNode(first, last);
            var rightFirst = middle.Next;
            middle.Next = null;
            if (last != null)
                last.Next = null;

            var sortedFirst = MergeSort(first, middle);
            var sortedSecond = MergeSort(rightFirst, last);

            return MergeSortedLinkedLists(sortedFirst, sortedSecond);
        }

        private LinkedListNode MergeSortedLinkedLists(LinkedListNode left, LinkedListNode right)
        {           
            if (right == null)
                return left;

            if (left == null)
                return right;

            LinkedListNode head = left.Data > right.Data ? right : left;

            var l = left;
            var r = right;
            LinkedListNode lPrev = null;
            
            while(l != null || r != null)
            {
                if(l != null && r != null)
                {
                    if(l.Data < r.Data)
                    {
                        lPrev = l;
                        l = l.Next;
                    }
                    else
                    {
                        var temp = r.Next;
                        r.Next = l;
                        if(lPrev != null)
                        {
                            lPrev.Next = r;
                        }
                        lPrev = r;
                        r = temp;
                    }
                }
                else if( l == null && r != null )
                {
                    lPrev.Next = r;
                    lPrev = r;
                    r = r.Next;

                }
                else if( r == null && l != null)
                {
                    lPrev = l;
                    l = l.Next;
                }
            }

            return head;
        }

        public LinkedListNode findMiddleNode(LinkedListNode first, LinkedListNode last)
        {
            if(first.Next == last || first.Next == null)
            {
                return first;
            }

            if(first.Next.Next == last)
            {
                return first.Next;
            }

            var sPoint = first;
            var fPoint = first.Next.Next;

            while(fPoint != last)
            {
                sPoint = sPoint.Next;

                if (fPoint.Next == last)
                    break;

                fPoint = fPoint.Next.Next;
            }

            return sPoint;
        }

        public bool isCycleExists(LinkedList list)
        {
            if (!(list != null && list.Head != null))
                return false;

            if (list.Head.Next == null)
                return false;

            var sPoint = list.Head;
            var fPoint = sPoint.Next.Next;

            while(fPoint != null)
            {
                if (sPoint == fPoint)
                    return true;

                if (fPoint.Next == null)
                    return false;

                sPoint = sPoint.Next;
                fPoint = fPoint.Next.Next;
            }

            return false;
        }

        public LinkedListNode FindNode(LinkedList list, int value)
        {
            if (!(list != null && list.Head != null))
                return null;

            var temp = list.Head;

            while(temp != null)
            {
                if (temp.Data == value)
                    return temp;

                temp = temp.Next;
            }

            return null;

        }
    }
}
