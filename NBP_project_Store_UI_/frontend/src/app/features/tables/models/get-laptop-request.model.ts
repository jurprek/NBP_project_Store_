import internal from "stream"

export interface GetLaptopRequest {
    id_Laptop: string,
    model: string,
    processor: {
      type: string,
      cores: number,
      maxSpeedGHz: number
    },
    ram: {
      sizeGB: number,
      type: string
    },
    screen: {
      sizeInches: number,
      resolution: string,
      type: string
    },
    storage: {
      sizeGB: number,
      type: string
    },
    os: string,
    graphics: {
      type: string
    },
    network: {
      wifi: string,
      ethernet: string,
      bluetooth: boolean
    },
    ports: {
      usB2_0: number,
      usB3_1: number,
      hdmi: boolean,
      usbTypeC: boolean
    },
    weightKg: number,
    color: string,
    warrantyMonths: number,
    additionalFeatures: [string, string]
  }