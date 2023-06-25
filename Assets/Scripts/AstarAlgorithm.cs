using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//휴리스틱 추정값
//다익스트라 알고리즘

public class AstarAlgorithm
{
    //Find optimized Path from start Node to end Node
    public static IEnumerator FindPath(Anode start, Anode End)
    {
        yield return null;
        List<Anode> openList = new List<Anode>();

        //array past location without duplication
        HashSet<Anode> closedList = new HashSet<Anode>();

        openList.Add(start);
        while(openList.Count > 0)
        {
            Anode currentNode = openList[0];
            for(int i = 1; i < openList.Count; i++)
            {
                //openList는 탐색이 아직 되지 않은, 탐색해야 하는 리스트
                //fcost가 작거나 fcost가 같고 hcost(추정치)가 작으면
                if(openList[i].fCost < currentNode.fCost ||
                    openList[i].fCost == currentNode.fCost &&
                    openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }

            //탐색이 더는 필요없는 currentNode를 제거
            //탐색이 완료된 currentNode를 closedList에 추가
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            //탐색 종료
            if (currentNode == End)
            {
                yield break;
            }

            //계속 탐색
            
        }
    }

}
