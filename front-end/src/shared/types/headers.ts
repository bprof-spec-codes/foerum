export const baseHeader = {
  headers: {
    Authorization: localStorage
      ? localStorage.getItem("token")
      : sessionStorage.getItem("token"),
  },
};
