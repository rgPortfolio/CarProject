import { get, post, put, patch } from "./RequestService";
import { CarProjectApi } from "./AxiosInstance";
import { Car } from "./../Models/car";
const mockCarProjectApi = CarProjectApi as jest.Mocked<typeof CarProjectApi>;
jest.mock("./AxiosInstance");

describe("Request Service", () => {
  const url = "https://localhost:5001/api/car";

  const fakeCar = {
    Id: "123456",
    Make: "honda",
    Model: "Civic ex",
    Year: 2019,
  } as Car;

  const testCar = {
    Id: "123456",
    Make: "honda",
    Model: "Civic lx",
    Year: 20199,
  } as Car;

  const fakeData = [fakeCar];

  beforeEach(() => {
    jest.spyOn(console, "log").mockImplementation(() => {});
    mockCarProjectApi.get = jest.fn();
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  it("get", async () => {
    mockCarProjectApi.get.mockResolvedValue({ data: fakeData });

    const result = await get(url);

    expect(mockCarProjectApi.get).toHaveBeenCalled();
    expect(result).toBe(fakeData);
  });

  it("post", async () => {
    mockCarProjectApi.post.mockResolvedValue({
      data: { ...fakeCar },
      status: 201,
      headers: { location: `${url}/${fakeCar.Id}` },
    });

    const result = await post(url, { ...fakeCar });

    expect(mockCarProjectApi.post).toHaveBeenCalled();
    expect(result).toEqual(fakeCar.Id);
  });

  it("Post throws error", async () => {
    const expectedUrl = `fakeroute`;
    const error = new Error("Oh dear, something went wrong");

    mockCarProjectApi.post.mockRejectedValue(error);

    const response = mockCarProjectApi.post(expectedUrl, error);

    await expect(response).rejects.toThrow();
  });

  it("put 204", async () => {
    mockCarProjectApi.put.mockResolvedValue({
      data: { ...testCar },
      status: 204,
    });

    const result = await put(url, { ...fakeCar });

    expect(mockCarProjectApi.put).toHaveBeenCalled();
    expect(result).toEqual({ ...fakeCar });
  });

  it("put 202", async () => {
    mockCarProjectApi.put.mockResolvedValue({
      data: { ...testCar },
      status: 202,
    });

    const result = await put(url, { ...testCar });

    expect(mockCarProjectApi.put).toHaveBeenCalled();
    expect(result).toEqual({ ...testCar });
  });

  it("put throws error", async () => {
    const expectedUrl = `fakeroute`;
    const error = new Error("Oh dear, something went wrong");

    mockCarProjectApi.put.mockRejectedValue(error);

    const response = mockCarProjectApi.put(expectedUrl, error);

    await expect(response).rejects.toThrow();
  });

  it("patch", async () => {
    mockCarProjectApi.patch.mockResolvedValue({ status: 204 });

    const result = await patch(url, { ...fakeCar });

    expect(mockCarProjectApi.patch).toHaveBeenCalled();
    expect(result).toEqual({ ...fakeCar });
  });

  it("Patch throws error", async () => {
    const expectedUrl = `fakeroute`;
    const error = new Error("Oh dear, something went wrong");

    mockCarProjectApi.patch.mockRejectedValue(error);

    const response = mockCarProjectApi.patch(expectedUrl, error);

    await expect(response).rejects.toThrow();
  });
});
