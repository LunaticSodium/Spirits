using BaseLib.Abstracts;
using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using Spirits.Cards.Basic;
using Spirits.Relics;
using System.Collections.Generic;

namespace Spirits.Character;

public class Spirits : PlaceholderCharacterModel
{
    public static readonly Color Color = new("c4278a");

    public override string PlaceholderID => "necrobinder";
    public override Color NameColor => Color;

    public override int StartingHp => 88;
    public override int StartingGold => 99;

    public override CharacterGender Gender => CharacterGender.Neutral;

    /*public override IEnumerable<IReadOnlyList<CardModel>> CardBundles => [
        [
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<StrikeSpirits>()
        ],
        [
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<DefendSpirits>()
        ]
    ];*/

    public override CardPoolModel CardPool => ModelDb.CardPool<SpiritsCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<SpiritsRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<SpiritsPotionPool>();

    public override IEnumerable<CardModel> StartingDeck => [
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<StrikeSpirits>(),
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<DefendSpirits>(),
            ModelDb.Card<Earthshatter>(),
            ModelDb.Card<ThunderClap>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics => [ModelDb.Relic<CorrodedRibbon>()];


    //Visuals
    public override string CustomVisualPath => "res://scenes/spirits/spirits.tscn";
    public override string CustomIconTexturePath => "res://images/spirits/character_icon_spirits.png";
    public override string CustomCharacterSelectIconPath => "res://images/spirits/char_select_spirits.png";
    public override string CustomCharacterSelectLockedIconPath => "res://images/spirits/char_select_spirits_locked.png";
    public override string CustomMapMarkerPath => "res://images/spirits/map_marker_spirits.png";
}
