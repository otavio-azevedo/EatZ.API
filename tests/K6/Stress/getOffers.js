import http from "k6/http";
import { check } from "k6";

export let options = {
  insecureSkipTLSVerify: true,
  noConnectionReuse: true,
  stages: [
    { duration: "5s", target: 1 },
    { duration: "10s", target: 5 },
    { duration: "1m", target: 50 },
    { duration: "2m", target: 50 },
    { duration: "10s", target: 5 },
    { duration: "5s", target: 0 },
  ],
  thresholds: {
    http_req_failed: ["rate<0.01"],
    http_req_duration: ["p(95) < 1000"],
  },
  ext: {
    loadimpact: {
      projectID: 3639117,
      name: "Stress Test - Offers [GET]",
    },
  },
};

const API_URL = "http://localhost:8080/api";
const REQUEST_PARAMS = {
  headers: {
    "Content-Type": "application/json",
    Authorization:
      "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlcyI6IkNvbXBhbnkiLCJzdWIiOiJKV1QgZm9yIEVhdFogYXV0aCIsImp0aSI6ImY4Nzg5YTJiLTVhODEtNDZlYy05NDExLTI0NThlOTA1MDU2MSIsImlhdCI6IjA1LzA3LzIwMjMgMjE6Mjc6MjIiLCJ1c2VyX2lkIjoiODlhMWZiYzItYTJhNC00MWFlLTkwNjYtOWM5ZjY3ZWJlZGM0IiwibmFtZSI6InN0cmluZyIsImVtYWlsIjoidXNlckBleGFtcGxlLmNvbSIsImV4cCI6MTY4MzQ5ODQ0MiwiaXNzIjoiRWF0WiIsImF1ZCI6IkVhdFoifQ.oGTxySaqXOtIhcvhNlH9BoogXAY2HVJbfEcZK6P-5Bk",
  },
};

export default () => {
  const result = http.get(API_URL + "/offers/city?CityId=4137", REQUEST_PARAMS);

  check(result, {
    "is status 200": (r) => r.status === 200,
  });
};
