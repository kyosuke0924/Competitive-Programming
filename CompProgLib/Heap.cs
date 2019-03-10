using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompProgLib
{

    public class Heap<T> where T : IComparable<T>
    {
        public T[] BinaryHeap { get; private set; }
        public int Count { get; private set; }

        
        public Heap(int n)
        {
            BinaryHeap = new T[n];
            Count = 0;
        }

        // 幅優先探索の順に表示する関数
        public string breadthFirstSearch()
        {
            return String.Join(" ", BinaryHeap.Select(x => x.ToString()).ToArray());
        }

        // 新しい節点を二分ヒープに挿入する関数
        // 成功した場合は1を、失敗した場合は0を返す
        public bool insertNode(T value)
        {
            // 既にvalueがある場合はなにもしない
            if (searchNode(value, 0) != -1)
            {
                return false;
            }
            // 暫定的に最後尾に挿入
            BinaryHeap[Count] = value;
            int i = Count;

            // 最後尾から根まで辿って行く
            while (i > 0)
            {
                // 親の方が大きい場合
                if (BinaryHeap[i].CompareTo(BinaryHeap[(i - 1) / 2]) < 0)
                {
                    // 親と子を交換
                    BinaryHeap[i] = BinaryHeap[(i - 1) / 2];
                    BinaryHeap[(i - 1) / 2] = value;
                    i = (i - 1) / 2;
                }
                // 親の方が小さい場合
                else
                {
                    Count++;
                    return true;

                }
            }

            Count++;
            return true;
        }

        // valueをデータに持つ節点を二分ヒープから削除する関数
        // 成功した場合は1を、失敗した場合は0を返す
        public bool deleteNode(T value)
        {
            int index = searchNode(value, 0);
            // binaryHeap内にvalueがない場合は何もしない
            if (index == -1)
            {
                return false;
            }

            // 最後尾のデータを暫定的に移動
            BinaryHeap[index] = BinaryHeap[Count - 1];
            // binaryHeap[index]に対して子がいる限りループする
            // 節点の総数は1つ減っているので注意
            while (2 * index + 1 < Count - 1)
            {
                int childIndex;
                T childValue;

                // 左の子しかいない場合
                if (2 * index + 1 == Count - 2)
                {
                    childIndex = 2 * index + 1;
                    childValue = BinaryHeap[2 * index + 1];
                }
                // 左右の子がいる場合
                else
                {
                    // 左の子の方が小さい場合
                    if (BinaryHeap[2 * index + 1].CompareTo(BinaryHeap[2 * index + 2]) <= 0)
                    {
                        childIndex = 2 * index + 1;
                        childValue = BinaryHeap[2 * index + 1];
                    }
                    // 右の子の方が小さい場合
                    else
                    {
                        childIndex = 2 * index + 2;
                        childValue = BinaryHeap[2 * index + 2];
                    }
                }

                //  小さい方の子と現在位置を比べる
                //  現在位置の方が大きい場合
                if (BinaryHeap[index].CompareTo(childValue) > 0)
                {
                    //  現在位置と子を入れ替える
                    BinaryHeap[childIndex] = BinaryHeap[index];
                    BinaryHeap[index] = childValue;
                    index = childIndex;
                }
                //  子の方が大きい場合
                else
                {
                    Count--;
                    return true;
                }
            }

            Count--;
            return true;
        }

        //  valueをデータに持つ節点を二分ヒープから探索する関数
        //  成功した場合はその節点のインデックスを、失敗した場合は-1を返す
        public int searchNode(T value, int index)
        {
            // 節点の数が0の場合は何もしない
            if (Count == 0)
            {
                return -1;
            }

            // 行きがけ順で走査します
            // 探索成功
            if (BinaryHeap[index].CompareTo(value) == 0)
            {
                return index;
            }

            // 探索失敗
            else if (BinaryHeap[index].CompareTo(value) > 0)
            {
                return -1;
            }

            // まだ続ける
            else
            {
                int leftResult = -1;
                int rightResult = -1;
                if (2 * index + 1 < Count)
                {
                    leftResult = searchNode(value, 2 * index + 1);
                }
                if (2 * index + 2 < Count)
                {
                    rightResult = searchNode(value, 2 * index + 2);
                }

                if (leftResult == -1 && rightResult == -1)
                {
                    return -1;
                }
                else if (leftResult != -1)
                {
                    return leftResult;
                }
                else
                {
                    return rightResult;
                }
            }
        }


    }

}
