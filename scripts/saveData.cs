[System.Serializable]
public class saveData
{
    public float score;
    public bool first = true;
    public saveData(playerData player) {
        score = player.score;
        first = false;
        //name of selected gun
        //money
        //music volume 
        //array of bools(unlocked guns)
    }
}
