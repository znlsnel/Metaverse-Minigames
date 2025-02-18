using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject prevBlock;
    [SerializeField] Transform animTarget;
    [SerializeField] float speed;

    GameObject curBlock;
    bool moveXAxis = true;

    Coroutine moveBlock;

    public void Start()
    {
		curBlock = Instantiate<GameObject>(blockPrefab);
        SetYPos(prevBlock, curBlock);
        SetYPos(prevBlock, animTarget.gameObject);
        curBlock.transform.localScale = prevBlock.transform.localScale;
		moveBlock = StartCoroutine(MoveBlock(curBlock));

	}

    public void OnClick()
    {

        float dist = 0;
        if (moveXAxis)
			dist = Math.Abs(curBlock.transform.position.x - prevBlock.transform.position.x);
		else
			dist = Math.Abs(curBlock.transform.position.z - prevBlock.transform.position.z); 
         

		float sizeY = prevBlock.transform.localScale.y;
		float sizeZ = prevBlock.transform.localScale.z;
		float sizeX = prevBlock.transform.localScale.x;

		if (dist < 0.1f)
		{
            Debug.Log("콤보");
			dist = 0.0f;
		}
        else
        {
			if (moveXAxis)
				sizeX -= dist;
			else
				sizeZ -= dist;
		}


		// 슬라이스 ( 남는 블록 )
		curBlock.transform.localScale = new Vector3(sizeX, sizeY, sizeZ); // 크기 세팅

		// 위치값 세팅

		Vector3 pos = prevBlock.transform.position;
		pos.y = curBlock.transform.position.y;
		if (moveXAxis)
		{
			if (curBlock.transform.position.x > prevBlock.transform.position.x)
				pos.x += dist / 2;
			else
				pos.x -= dist / 2;
		}
		else
		{
			if (curBlock.transform.position.z > prevBlock.transform.position.z)
				pos.z += dist / 2;
			else 
				pos.z -= dist / 2;
		}
		curBlock.transform.position = pos;

		if (dist >= 0.1f)
		{
			// 슬라이스 ( 떨어지는 블록)
			var go = Instantiate<GameObject>(blockPrefab);
			var bb = curBlock.transform.localScale/2;
			if (moveXAxis)
			{
				sizeX = dist;
				if (curBlock.transform.position.x > prevBlock.transform.position.x)
					pos.x += bb.x +dist / 2;
				else
					pos.x -= bb.x + dist / 2;
			}
			else
			{
				sizeZ = dist;
				if (curBlock.transform.position.z > prevBlock.transform.position.z)
					pos.z += bb.z + dist / 2;
				else
					pos.z -= bb.z + dist / 2;
			}
			go.transform.localScale = new Vector3(sizeX, sizeY, sizeZ); // 크기 세팅
			go.transform.position = pos;
			go.AddComponent<Rigidbody>();	
		}
			
		



		prevBlock = curBlock;
        // 새로운 블록 생성
        curBlock = Instantiate<GameObject>(blockPrefab);
		curBlock.transform.localScale = prevBlock.transform.localScale;
		curBlock.transform.position = prevBlock.transform.position;

		SetYPos(prevBlock, curBlock);
		SetYPos(prevBlock, animTarget.gameObject);

		// 블록 움직이기
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
		moveXAxis = !moveXAxis;
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
