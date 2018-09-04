
import { SET_CATEGORIES, CATEGORY_DELETED, CATEGORY_ADDED, CATEGORY_UPDATED, SET_CATEGORY } from '../actions/categories';

export default function categoriesReducer(state = [], action = {}){
    
    switch(action.type){

        case SET_CATEGORIES:   
            return { ...state, categories: action.payload };
        
        case SET_CATEGORY:   
            return { ...state, category: action.payload };

        case CATEGORY_DELETED: 
            return { ...state, categories: state.categories.filter(item => item.id !== action.payload) };
 
        case CATEGORY_ADDED: 
            return { ...state, categories: (state.categories || []).concat([action.payload]) };

        case CATEGORY_UPDATED:
            
        default:
            return state;
        
    } 
}