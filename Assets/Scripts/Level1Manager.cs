using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    private LevelGrid level1;
    private GameObject[,] tileObjects;
    private List<PlayerUnit> playerUnits;
    private List<EnemyUnit> enemyUnits;
    private int cursorX;
    private int cursorY;
    private Color originalTileColor;
    private int selectedX;
    private int selectedY;
    private Unit selectedUnit;
    public ButtonManager ButtonManager;
    public int turn;
    public TurnBox turnBox;

    private GameObject PlaceTile(Tile tile)
    {
        // Create GaemObject that will define which type of tile will be generated.
        GameObject tileGameObject;

        // Choose the correct tile based on the specified tile height.
        if (tile.GetHeight() == 1)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile1") as GameObject, transform);
        }
        else if (tile.GetHeight() == 2)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile2") as GameObject, transform);
        }
        else if (tile.GetHeight() == 3)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile3") as GameObject, transform);
        }
        else if (tile.GetHeight() == 4)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile4") as GameObject, transform);
        }
        else if (tile.GetHeight() == 5)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile5") as GameObject, transform);
        }
        else if (tile.GetHeight() == 6)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile6") as GameObject, transform);
        }
        else if (tile.GetHeight() == 7)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile7") as GameObject, transform);
        }
        else if (tile.GetHeight() == 8)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile8") as GameObject, transform);
        }
        else if (tile.GetHeight() == 9)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile9") as GameObject, transform);
        }
        else
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile10") as GameObject, transform);
        }

        tileGameObject.transform.localPosition = tile.GetTilePosition();

        return tileGameObject;
    }

    private void ManageTileCursorInputs()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if (cursorY < tileObjects.GetLength(0) - 1)
            {
                cursorY++;
            }
            if (cursorX < tileObjects.GetLength(1) - 1)
            {
                cursorX++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if ((cursorY % 2 == 0 && cursorX % 2 == 0) || (cursorY % 2 != 0 && cursorX % 2 != 0))
            {
                if (cursorY < tileObjects.GetLength(0) - 1)
                    cursorY++;
                else if (cursorX > 0)
                    cursorX--;
            }
            else
            {
                if (cursorX > 0)
                    cursorX--;
                else if (cursorY < tileObjects.GetLength(0) - 1)
                    cursorY++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (selectedUnit != null && IsWithinRadius(selectedUnit.GetStat("MOV"), selectedX, selectedY, cursorX, cursorY)){
                tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = new Color(0.35f, 0.4f, 0.7f, 1.0f);
            } else {
                tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;
            }
            

            if (cursorY > 0)
            {
                cursorY--;
            }
            if (cursorX > 0)
            {
                cursorX--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if ((cursorY % 2 == 0 && cursorX % 2 == 0) || (cursorY % 2 != 0 && cursorX % 2 != 0))
            {
                if (cursorX < tileObjects.GetLength(1) - 1)
                    cursorX++;
                else if (cursorY > 0)
                    cursorY--;
            }
            else
            {
                if (cursorY > 0)
                    cursorY--;
                else if (cursorX < tileObjects.GetLength(1) - 1)
                    cursorX++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Todo: logic for selecting unit
            // Debug.Log($"Selected tile at position ({cursorX},{cursorY})");
            Unit unit = level1.GetTileAt(cursorX, cursorY).GetOccupyingUnit();
            int radius = 0;
            
            if (unit != null){
                selectedUnit = unit;
                radius = selectedUnit.GetStat("MOV");
                ClearUnitMoveTiles(radius, selectedX, selectedY);
                
                SelectionManager.Instance.SelectUnit(unit);
                selectedX = cursorX;
                selectedY = cursorY;

                ButtonManager.showUnitUI();
                ShowUnitMoveTiles(radius, selectedX, selectedY);
            }
        }
    }

    private void ShowUnitMoveTiles(int r, int currX, int currY){

        for (int x = -r; x <= r; x++){
            for (int y = -r; y <= r; y++){
                int distance = Mathf.Abs(x) + Mathf.Abs(y);

                if (distance <= r){
                    int targetX = currX + x;
                    int targetY = currY + y;

                    if (targetX >= 0 && targetX < tileObjects.GetLength(0) && targetY >= 0 && targetY < tileObjects.GetLength(1)){
                        tileObjects[targetX, targetY].GetComponent<Renderer>().material.color = new Color(0.35f, 0.4f, 0.7f, 1.0f);
                    }
                }
            }
        }
    }

    private void ClearUnitMoveTiles(int r, int currX, int currY){

        for (int x = -r; x <= r; x++){
            for (int y = -r; y <= r; y++){
                int distance = Mathf.Abs(x) + Mathf.Abs(y);

                if (distance <= r){
                    int targetX = currX + x;
                    int targetY = currY + y;

                    if (targetX >= 0 && targetX < tileObjects.GetLength(0) && targetY >= 0 && targetY < tileObjects.GetLength(1)){
                        tileObjects[targetX, targetY].GetComponent<Renderer>().material.color = originalTileColor;
                    }
                }
            }
        }
    }

    public bool IsWithinRadius(int r, int currX, int currY, int targetX, int targetY)
    {  
        if (selectedUnit == null){
            Debug.Log("No unit selected");
            return false;
        }
        int distance = Mathf.Abs(targetX - currX) + Mathf.Abs(targetY - currY);

        if (distance <= r && targetX >= 0 && targetX < tileObjects.GetLength(0) && targetY >= 0 && targetY < tileObjects.GetLength(1)){
            return true;
        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        level1 = new LevelGrid();
        level1.LoadGrid("Level1");
        tileObjects = new GameObject[level1.GetRows(), level1.GetCols()];
        playerUnits = new List<PlayerUnit>();
        enemyUnits = new List<EnemyUnit>();

        for (int i = 0; i < level1.GetRows(); i++)
        {
            for (int j = 0; j < level1.GetCols(); j++)
            {
                tileObjects[i, j] = PlaceTile(level1.GetTileAt(i, j));
            }
        }

        cursorX = 0;
        cursorY = 0;
        originalTileColor = tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color;

        // Todo: Place units.
        playerUnits.Add(Instantiate(Resources.Load("Prefabs/Unit/Warrior") as GameObject, transform).GetComponent<PlayerUnit>());
        playerUnits[0].Init("Gerald", ClassType.Warrior);
        playerUnits.Add(Instantiate(Resources.Load("Prefabs/Unit/Mage") as GameObject, transform).GetComponent<PlayerUnit>());
        playerUnits[1].Init("Lex", ClassType.Mage);
        playerUnits.Add(Instantiate(Resources.Load("Prefabs/Unit/Rogue") as GameObject, transform).GetComponent<PlayerUnit>());
        playerUnits[2].Init("Leroy", ClassType.Rogue);
        playerUnits.Add(Instantiate(Resources.Load("Prefabs/Unit/Archer") as GameObject, transform).GetComponent<PlayerUnit>());
        playerUnits[3].Init("Aragon", ClassType.Archer);
        // initialize each playerUnit to their tile
        level1.GetTileAt(2, 3).SetOccupyingUnit(playerUnits[0]);
        level1.GetTileAt(2, 4).SetOccupyingUnit(playerUnits[1]);
        level1.GetTileAt(3, 4).SetOccupyingUnit(playerUnits[2]);
        level1.GetTileAt(4, 4).SetOccupyingUnit(playerUnits[3]);
        // move all units to their tile
        Vector3[] unitPosition = { level1.GetTileAt(2, 3).GetUnitPosition(), level1.GetTileAt(2, 4).GetUnitPosition(),
        level1.GetTileAt(3, 4).GetUnitPosition(), level1.GetTileAt(4, 4).GetUnitPosition()};
        for (int i = 0; i < playerUnits.Count; i++)
        {
            playerUnits[i].Move(unitPosition[i]);
        }
    }
    
    public bool MoveUnit() {
        Unit unit = SelectionManager.Instance.GetUnit(); 
        int radius = unit.GetStat("MOV");

        if (unit != null && IsWithinRadius(radius, selectedX, selectedY, cursorX, cursorY)){
            Tile tile = level1.GetTileAt(cursorX, cursorY);
            level1.GetTileAt(selectedX, selectedY).RemoveOccupyingUnit();
            tile.SetOccupyingUnit(unit);
            //does not move if the tile deems if a unit is already there
            unit.Move(tile.GetUnitPosition());

            //changes order in layer
            SpriteRenderer spriteRenderer = unit.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null){
                Debug.Log("Changed sprite order");
                spriteRenderer.sortingOrder = (10 - cursorY) * 2 + 1; 
            }

            selectedUnit = null;
            ClearUnitMoveTiles(radius, selectedX, selectedY);
            return true;

        } else {
            Debug.Log("Tile out of range");
            return false;
        }
    }

    public bool AttackUnit() {
    Unit unit = SelectionManager.Instance.GetUnit(); 
    Unit target = level1.GetTileAt(cursorX, cursorY).GetOccupyingUnit();

        if (unit != null && target != null && IsWithinRadius(1, selectedX, selectedY, cursorX, cursorY)){
            unit.Attack(target);
            return true;

        } else {
            Debug.Log("Error with attack");
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedUnit != null){
            int radius = selectedUnit.GetStat("MOV");
            ShowUnitMoveTiles(radius, selectedX, selectedY);
        }
        tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = new Color(0.17f, 0.68f, 1.0f, 1.0f);
        ManageTileCursorInputs();
    }

    public void newPlayerTurn(){
        for (int i = 0; i < playerUnits.Count; i++){
            playerUnits[i].unsetAttack();
            playerUnits[i].unsetMove();
            playerUnits[i].unsetPass();
        }
        turn++;
        turnBox.DisplayTurnText();
    }

    public int getTurn(){
        return turn;
    }
}

