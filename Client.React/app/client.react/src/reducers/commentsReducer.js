
import { ADD_COMMENT } from '../actions/comments';

export default function commentsReducer(state = [], action = {}){
    
    switch(action.type){

        case ADD_COMMENT: 
            return { ...state, comments: (state.comments || []).concat([action.payload]) };

        default:
            return state;
        
    } 
}