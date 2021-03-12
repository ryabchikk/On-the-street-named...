using System;
using System.Collections;

public class CyclicCollection<T> : IEnumerable, IEnumerator, IDisposable
{
    public object Current => _elements[_position];
    public int Length => _actualSize;

    private T[] _elements;
    private int _position = -1;
    private int _actualSize;

    public CyclicCollection(T[] objects)
    {
        _elements = objects;
        _actualSize = objects.Length;
    }

    public CyclicCollection(int size)
    {
        _elements = new T[size];
        _actualSize = 0;
    }

    public CyclicCollection()
    {
        _elements = new T[1];
        _actualSize = 0;
    }

    public T this[int index]
    {
        get
        {
            if (index >= 0 && index < _actualSize)
                return _elements[index];
            else
                throw new IndexOutOfRangeException($"Index {index} is out of bounds of the collection");
        }

        private set
        {
            if (_elements.Length > _actualSize)
            {
                _elements[_actualSize] = value;
                _actualSize++;
            }
            else
            {
                T[] temp = new T[_elements.Length * 2];
                _elements.CopyTo(temp, 0);
                _elements = temp;
                _elements[_actualSize] = value;
                _actualSize++;
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        if (_position < _elements.Length - 1)
        {
            _position++;
            return true;
        }
        else
        {
            _position = 0;
            return false;
        }
    }

    public void Reset()
    {
        _position = -1;
    }

    public void Add(T obj)
    {
        this[_actualSize] = obj;
    }

    public void Dispose()
    {
        Reset();
    }
}
