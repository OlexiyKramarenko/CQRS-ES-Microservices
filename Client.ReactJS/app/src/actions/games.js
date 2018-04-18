
//По этому ключу редюсер все поймет
export const SET_GAMES = "SET_GAMES";

//Тупо AJAX запрос
export function fetchGames() {
    // return dispatch => {
    //     fetch('/api/games')
    //         .then(res => res.json()) //конвертированть в json обьект
    //         .then(data => dispatch(setGames(data.games)));
    // }
    return dispatch => {dispatch(setGames(["one", "two", "three"]))};
}

//а это уже экшн
export function setGames(games) {
    return {
        type: SET_GAMES,
        games 
    }
}