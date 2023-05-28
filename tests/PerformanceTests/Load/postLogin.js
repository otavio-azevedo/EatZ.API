import http from "k6/http";
import { check } from "k6";

export let options = {
  insecureSkipTLSVerify: true,
  noConnectionReuse: true,
  stages: [
    { duration: "30s", target: 25 },
    { duration: "2m", target: 25 },
    { duration: "30s", target: 0 },
  ],
  thresholds: {
    http_req_failed: ["rate<0.01"],
    http_req_duration: ["p(95) < 1000"],
  },
  ext: {
    loadimpact: {
      projectID: 3639117,
      name: "Load Test - Login [POST]",
    },
  },
};

const API_URL = "http://localhost:8080/api";
const REQUEST_PARAMS = {
  headers: {
    "Content-Type": "application/json",
  },
};
const payload = JSON.stringify({
  email: "k6@example.com",
  password: "123456",
});

export default () => {
  const result = http.post(API_URL + "/auth/login", payload, REQUEST_PARAMS);

  check(result, {
    "is status 200": (r) => r.status === 200,
    "is authenticated": (r) => r.body.includes("k6"),
  });
};
