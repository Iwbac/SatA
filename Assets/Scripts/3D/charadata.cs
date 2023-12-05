using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Create StatusData")]
public class charadata : ScriptableObject
{
    public string NAME; //キャラ・敵名
    public int MAXHP; //最大HP
    public int ATK; //攻撃力
    public int DEF; //防御力

}