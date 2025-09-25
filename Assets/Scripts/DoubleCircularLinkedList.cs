using Unity.VisualScripting;
using UnityEngine;

public class DoubleCircularLinkedList<T>
{
    #region  Properties
    private Node<T> head = null;
    private Node<T> tail = null;

    private int count = 0;
    #endregion
    #region Methods
    public virtual void Add(T value)
    {
        Node<T> temp = new(value);
        count++;

        if(head == null)
        {
            head = temp;
            tail = temp;
            head.SetNext(tail);
            tail.SetPrev(head);
        }
        else
        {
            temp.SetNext(head);
            temp.SetPrev(tail);
            head.SetPrev(temp);
            tail.SetNext(temp);
            head = temp;
        }
        
    }
    public virtual void ReadForward(Node<T> start,int depth = 0)
    {
        if (start == null || depth >= count) return;

        Debug.Log("El valor es " + start.Value);

        ReadForward(start.Next, depth + 1);
    }
    public virtual void ReadBackwards(Node<T> start, int depth = 0)
    {
        if (start == null || depth >= count) return;

        Debug.Log("El valor es " + start.Value);

        ReadBackwards(start.Prev, depth + 1);
    }
    public virtual Node<T> Find(int pos , Node<T> start = null , int depth = 0)
    {
        if (depth >= count) throw new System.Exception("El elemnto ingresado no existe en la lista");

        if (start == null) start = head;
        if (pos == depth)
            return start;

        return Find(pos, start.Next , depth +1);
    }

    public virtual void Remove(int pos)
    {
        Node<T> objective = Find(pos);

        if (objective == null || head == null) return;


        //-> Si es el primero
        if(objective == head && count > 1)
        {
            Node<T> temp = head;
            head = objective.Next;
            head.SetPrev(tail);
            temp.Clear();
            count--;
            return;
        }
        else if (objective == head && count == 1)
        {
            RemoveAll();
            return;
        }
        //->El medio
        if(objective != head && objective != tail)
        {
            objective.Prev.SetNext(objective.Next);
            objective.Next.SetPrev(objective.Prev);
            objective.Clear();
            count--;
            return;
        }
        //-> El ultimo
        if(objective == tail)
        {
            Node<T> temp = tail;
          //  tail.Clear();

            tail = objective.Prev;
            tail.SetNext(head);
            temp.Clear();
            count--;
            return;
        }


    }

    public void RemoveAll()
    {
        head.Clear();
        tail.Clear();   
    }



    #endregion
    #region Getters
    public Node<T> Head => head;
    public Node<T> Tail => tail;
    public int Count => count;

    #endregion


}
