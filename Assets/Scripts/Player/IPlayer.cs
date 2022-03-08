using JobTest.Killable;
using UnityEngine;

namespace JobTest.Player
{
    public interface IPlayer : IKillable
    {
        Transform Transform { get; }
        PlayerController PlayerController {get;}
    }
}