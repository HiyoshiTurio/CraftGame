using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InGameManager : MonoBehaviour
{
    private static InGameManager _instance;
    private List<Transform> _characterTransforms = new List<Transform>();
    private Camera _camera;
    public Transform playerTransform;

    public static InGameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _camera = Camera.main;
    }

    public void AddCharacterTransforms(Transform transforms)
    {
        _characterTransforms.Add(transforms);
    }

    public void RemoveCharacterTransforms(Transform transforms)
    {
        _characterTransforms.Remove(transforms);
    }

    public void CheckHitAttack(Transform attackCharaTransform, int damage)
    {
        Vector2 direction = (_camera.ScreenToWorldPoint(Input.mousePosition) - attackCharaTransform.position).normalized;
        float range = 1; //攻撃範囲
        float angleRange = 60; //攻撃角度範囲
        for(int i = 0; i < _characterTransforms.Count; i++)
        {
            Transform targetTransform = _characterTransforms[i];
            if ( targetTransform != attackCharaTransform)
            {
                if (attackCharaTransform.position.x -  attackCharaTransform.position.x * attackCharaTransform.position.x -
                     targetTransform.position.x +
                    attackCharaTransform.position.y -  attackCharaTransform.position.y * attackCharaTransform.position.y -
                     targetTransform.position.y <=
                    range * range)
                {
                    float dot = Vector2.Dot(direction.normalized, attackCharaTransform.position);
                    if (dot > Mathf.Cos(angleRange))
                    {
                        targetTransform.GetComponent<CharacterBase>().DamageAction(damage);
                    }
                }
                else
                {
                }
            }
        }
    }
}