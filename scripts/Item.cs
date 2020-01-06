using System.Collections;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;


public class Item
{
    [XmlAttribute("name")]
    public string name;

    [XmlElement("damage")]
    public int damage;
    [XmlElement("autoFire")]
    public bool autoFire;
    [XmlElement("buletspeed")]
    public float buletspeed;
    [XmlElement("fireRate")]
    public float fireRate;
    [XmlElement("explosive")]
    public bool explosive;
    [XmlElement("id")]
    public float id;
}
