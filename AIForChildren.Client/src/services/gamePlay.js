import {
    http
} from "../utils/http";

const AuthenticationService = {
    async play() {
        var result = await http.get("https://localhost:5001/api/game/oyunListele");
        if (result.status === 200) {
            return result.data;
        } else {
            console.error(result.error);
            throw result.error;
        }
    }
};

export default AuthenticationService;