using UnityEngine;

public class Define
{
    #region Animator Parameter
    public static readonly int SpeedHash = Animator.StringToHash("Speed");
    public static readonly int IsGroundHash = Animator.StringToHash("IsGround");
    public static readonly int DieHash = Animator.StringToHash("Die");
    public static readonly int AttackHash = Animator.StringToHash("Attack");
    public static readonly int FlipHash = Animator.StringToHash("Flip");
    #endregion

    #region Tag
    public const string PlayerTag = "Player";
    public const string EnemyTag = "Enemy";
    public const string SpikeTag = "Spike";
    #endregion

    #region Constants
    public const int PlayerMaxHp = 3;
    #endregion

    #region Scene
    public const string GameScene = "Game";
    public const string MainScene = "Main";
    #endregion
}
