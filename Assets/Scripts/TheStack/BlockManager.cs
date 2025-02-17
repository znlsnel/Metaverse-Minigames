using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject prevBlock;
    [SerializeField] float speed;

    GameObject curBlock;
    bool moveXAxis = true;

    Coroutine moveBlock;

    public void Start()
    {

		curBlock = Instantiate<GameObject>(blockPrefab);
        SetYPos(prevBlock, curBlock);
        curBlock.transform.localScale = prevBlock.transform.localScale;
        moveBlock = StartCoroutine(MoveBlock(curBlock));
	}

    public void OnClick()
    {
        moveXAxis = !moveXAxis;

		float dist = (curBlock.transform.position - prevBlock.transform.position).magnitude;

		float sizeY = prevBlock.transform.localScale.y;
		float sizeZ = prevBlock.transform.localScale.z;
		float sizeX = prevBlock.transform.localScale.x;

		if (dist < 0.1f)
        {
            // TODO
            // ÄÞº¸! 
        }
        else
        {
			if (moveXAxis)
				sizeX -= dist;
			else
				sizeZ -= dist;
		}
        

        curBlock.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
        prevBlock = curBlock;
         
        curBlock = Instantiate<GameObject>(blockPrefab);
		SetYPos(prevBlock, curBlock);
        curBlock.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);

        if (moveBlock != null)
            StopCoroutine(moveBlock);
        moveBlock = StartCoroutine(MoveBlock(curBlock)); 
	}

    void SetYPos(GameObject prev, GameObject cur)
    {
		float y = prev.transform.position.y;
		y += GetBoundingBox(prev).y;
         
		Vector3 pos = cur.transform.position; pos.y = y;
		cur.transform.position = pos;
	}

    Vector3 GetBoundingBox(GameObject go)
    {
        return go.GetComponent<MeshRenderer>().bounds.size;
    }

    IEnumerator MoveBlock(GameObject block)
    {
        float d = 1.0f;
        while (true)
        {
            Vector3 dir = new Vector3(Time.deltaTime * speed * d, 0.0f, Time.deltaTime * speed * d);

            if (moveXAxis)
                dir.z = 0.0f;
            else
                dir.x = 0.0f;

            block.transform.position += dir;

            float temp = block.transform.position.x;
            if (moveXAxis == false)
				temp = block.transform.position.z;

            if (temp > 2.0f)
                d = -1.0f;
            else if (temp < -2.0f)
                d = 1.0f;

			yield return null;
		}
	}
}
