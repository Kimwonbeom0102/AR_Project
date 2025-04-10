using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class chap8Controller : MonoBehaviour
{

    private bool isTouched = false;
    private GameObject selectedObj;
    [SerializeField] private Camera arCamera;

    [SerializeField] private LayerMask _selectMask;
    [SerializeField] private LayerMask _groundMask;

    private Vector3 initialPosition;

    [SerializeField] private GameObject uiTextObject; // 텍스트가 포함된 UI 오브젝트
    private Text uiText; // UI 텍스트 컴포넌트

    private void Start()
    {
        if (arCamera == null)
        {
            Debug.LogError("[Debug] : AR Camera not assigned.");
        }

        // UI 텍스트 초기화
        if (uiTextObject != null)
        {
            uiText = uiTextObject.GetComponent<Text>();
            if (uiText == null)
            {
                Debug.LogError("No Text component found on the assigned GameObject.");
            }

            //uiTextObject.SetActive(true); // 시작 시 UI 활성화
            uiText.text = "돼지 형제들을 나무로 옮겨주세요."; // 초기 텍스트 설정
        }
    }

    private void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        // 터치 시작
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _selectMask))
            {
                // 돼지가 선택되었는지 확인
                PigStatus pigStatus = hit.collider.GetComponent<PigStatus>();
                if (pigStatus != null && !pigStatus.isOnTree)
                {
                    selectedObj = hit.collider.gameObject;
                    initialPosition = selectedObj.transform.position;
                    isTouched = true;
                    selectedObj.layer = LayerMask.NameToLayer("ARSelected");
                    Debug.LogWarning("[Debug] : {selectedObj.name}");
                }
            }
        }

        // 터치 이동
        if (touch.phase == TouchPhase.Moved && isTouched && selectedObj != null)
        {
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundMask))
            {
                if (hit.collider.gameObject.name == "tree_2")
                {
                    Debug.LogWarning($"[Debug] : {selectedObj.name} hit TargetTree!");

                    // 고정 위치 설정
                    Vector3 fixedPosition = GetFixedPositionForObject(selectedObj.name);
                    selectedObj.transform.localPosition = fixedPosition;

                    // 돼지 상태 업데이트
                    selectedObj.GetComponent<PigStatus>().isOnTree = true;
                    Debug.LogWarning($"[Debug] : {selectedObj.name} is now on tree: {selectedObj.GetComponent<PigStatus>().isOnTree}");

                    Debug.LogWarning($"[Debug] : {selectedObj.name} fixed at {fixedPosition}");

                    // 모든 돼지가 나무에 고정되었는지 확인
                    CheckAllPigsOnTree();
                }
                else
                {
                    // 나무가 아닌 곳으로 이동
                    selectedObj.transform.position = hit.point;
                    Debug.LogWarning($"[Debug] : {selectedObj.name} moved to {hit.point}");
                }
            }
        }

        // 터치 종료
        if (touch.phase == TouchPhase.Ended && selectedObj != null)
        {
            isTouched = false;
            selectedObj.layer = LayerMask.NameToLayer("ARSelectable");

            if (!selectedObj.GetComponent<PigStatus>().isOnTree)
            {
                selectedObj.transform.position = initialPosition;
                Debug.LogWarning($"[Debug] : {selectedObj.name} reset to initial position");
            }
            else
            {
                Debug.LogWarning($"[Debug] : {selectedObj.name} remains at fixed position");
            }

            selectedObj = null;
        }
    }

    // 돼지 이름에 따라 고정 위치 반환
    private Vector3 GetFixedPositionForObject(string objectName)
    {
        switch (objectName)
        {
            case "FirstPig": return new Vector3(-0.68f, 7.18f, -1.07f); // FirstPig의 고정 위치
            case "SecondPig": return new Vector3(2.35f, 8.63f, -1.56f); // SecondPig의 고정 위치
            case "ThirdPig": return new Vector3(5.56f, 6.89f, -0.99f); // ThirdPig의 고정 위치
            default: return Vector3.zero; // 기본 위치는 0, 0, 0
        }
    }

    // 모든 돼지가 나무에 고정되었는지 확인
    private void CheckAllPigsOnTree()
    {
        bool allPigsOnTree = GameObject.FindGameObjectsWithTag("Pig").All(pig => pig.GetComponent<PigStatus>().isOnTree);
        Debug.LogWarning($"[Debug] : All pigs on tree: {allPigsOnTree}"); // 상태 확인

        if (allPigsOnTree)
        {
            if (uiTextObject != null)
            {
                Debug.LogWarning($"[Debug] : Hiding UI Text...");
                uiTextObject.SetActive(false); // 모든 돼지가 고정되면 UI 숨김
            }
            Debug.LogWarning("[Debug] : 모든 돼지가 나무에 고정되었습니다!");
        }
    }
}
