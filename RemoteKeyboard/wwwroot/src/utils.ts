export function range(size: number, startAt = 0, step = 1) {
    return [...Array(size).keys()].map(i => i * step + startAt);
}


