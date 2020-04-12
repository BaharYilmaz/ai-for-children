import {
  http
} from "../utils/http";

const AuthenticationService = {
  async save(value) {
    var result = await http.post("https://localhost:5001/api/auth/register", value);
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  },
  async login(value) {
    var result = await http.post("https://localhost:5001/api/auth/login", value);
    if (result.status === 200) {
      return result.data;
    } else {
      console.error(result.error);
      throw result.error;
    }
  }
};

export default AuthenticationService;