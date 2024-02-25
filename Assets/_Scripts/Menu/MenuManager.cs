using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    string highlightedText, normalText;

    private List<GameObject> MenuList = new List<GameObject>();
    public MenuInputHandler InputHandler { get; private set; }

    private GameObject currentMenu;

        // Start is called before the first frame update
        public void Start()
        {
            InputHandler = GetComponent<MenuInputHandler>();

            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++ )
            {
                GameObject chieldObject = transform.GetChild(i).gameObject;
                MenuList.Add(chieldObject);
            }

            this.Enter();
            SelectMenu(MenuList[0]);
            currentMenu = MenuList[0];
        }

        public void Enter()
        {
            InputHandler.MoveUpRequest += MoveUp;
            InputHandler.MoveDownRequest += MoveDown;
            InputHandler.MoveLeftRequest += MoveLeft;
            InputHandler.MoveRightRequest += MoveRight;
        }

        public void Exit()
        {
            InputHandler.MoveUpRequest -= MoveUp;
            InputHandler.MoveDownRequest -= MoveDown;
            InputHandler.MoveLeftRequest -= MoveLeft;
            InputHandler.MoveRightRequest -= MoveRight;
        }

        private void SelectMenu(GameObject gameObject)
        {
            if(gameObject == null)
            {
                Debug.LogError("Object is null");
            }

            currentMenu = gameObject;
            
            //Clear all menus before set new one.
            ClearMenu();
            
            //Change text color
            Text text = gameObject.GetComponentInChildren<Text>();
            Color color;
            if (UnityEngine.ColorUtility.TryParseHtmlString(highlightedText, out color))
            {
                text.color = color;
            } else {
                Debug.Log("Cannot convert hexadecimal");
            }

            //Active swords objects
            ChangeSwords(gameObject, true);
        }

        private void ClearMenu()
        {
            
            for (int i = 0; i < MenuList.Count; i++)
            {
                GameObject itemMenu = MenuList[i];
                ChangeSwords(itemMenu, false);

                Text text = itemMenu.GetComponentInChildren<Text>();
                Color color;
                if (UnityEngine.ColorUtility.TryParseHtmlString(normalText, out color))
                {
                    text.color = color;
                } else {
                    Debug.Log("Cannot convert hexadecimal");
                }
            }
        }
        
        private void ChangeSwords(GameObject gameObject, bool value)
        {
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(value);
            }
        }

        # region Moves Directions Funcitons
        private void MoveUp()
        {
            GameObject nextMenu;
            int index = MenuList.IndexOf(currentMenu);
            AudioManager.Instance.PlaySfx("MenuSwap2");

            if (index != -1)
            {
                int nextIndex = (index -1 + MenuList.Count) % MenuList.Count;
                nextMenu = MenuList[nextIndex];
                SelectMenu(nextMenu);
            } 
        }

        private void MoveDown()
        {
            GameObject previousMenu;
            int index = MenuList.IndexOf(currentMenu);
            AudioManager.Instance.PlaySfx("MenuSwap2");

            if (index != -1)
            {
                int previousIndex = (index +1) % MenuList.Count;
                previousMenu = MenuList[previousIndex];
                SelectMenu(previousMenu);
            } 
        }

        private void MoveRight()
        {
            Debug.Log("Move Right");
        }

        private void MoveLeft()
        {
            Debug.Log("Move Left");
        }
        # endregion
}

