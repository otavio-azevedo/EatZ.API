import http from "k6/http";
import { check, sleep } from "k6";

export let options = {
  insecureSkipTLSVerify: true,
  noConnectionReuse: true,
  vus: 1,
  duration: "1s",
  thresholds: {
    http_req_failed: ["rate==0"],
    http_req_duration: ["p(100)<50"],
  },
  ext: {
    loadimpact: {
      projectID: 3639117,
      name: "Smoke Test - Swagger",
    },
  },
};

const API_URL = "http://localhost:8080/swagger/index.html";

export default () => {
  const result = http.get(API_URL);
  check(result, {
    "is status 200": (r) => r.status === 200,
  });
  sleep(1);
};
