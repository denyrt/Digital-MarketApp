import { Collection } from '../models/collection.js';
import { Rarity } from '../models/rarity.js';

export interface Item
{
    id: string;
    imageUrl: string;
    marketName: string;
    description: string;
    dropChance: number;
    collection: Collection;
    rarity: Rarity;
}